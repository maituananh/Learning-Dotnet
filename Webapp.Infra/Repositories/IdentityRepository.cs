using Application.Repositories;
using Domain.domain;
using Infra.Configuration;
using Infra.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infra.Repositories;

public class IdentityRepository(
    SignInManager<User> signInManager,
    ApplicationDbContext dbContext,
    IConfiguration configuration
    ) : IIdentityRepository
{
    public async Task<Domain.User?> CheckPasswordAsync(Domain.User user)
    {
        var userEntity = await dbContext.Users
            .Where(u => u.UserName == user.Name)
            .SingleOrDefaultAsync();

        if (userEntity == null)
        {
            return null;
        }

        var identityResult = await signInManager.PasswordSignInAsync(userEntity, user.Password, false, false);

        return identityResult.Succeeded ? new Domain.User(
            id: userEntity.Id,
            name: userEntity.UserName!,
            email: userEntity.Email!
            ) : null;
    }

    public async Task<Token> GenerateToken(Domain.User user)
    {
        var signingKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Key")!));

        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Name, user.Name),
            new(JwtRegisteredClaimNames.Email, user.Email)
        ];

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = credentials,
            Issuer = configuration.GetValue<string>("Jwt:Issuer"),
            Audience = configuration.GetValue<string>("Jwt:Audience")
        };

        var tokenHanlder = new JwtSecurityTokenHandler();
        var accessToken = tokenHanlder.CreateToken(tokenDescriptor);

        return new Token
        {
            AccessToken = tokenHanlder.WriteToken(accessToken),
            RefreshToken = Guid.NewGuid().ToString(),
            ExpireAt = tokenDescriptor.Expires ?? DateTime.UtcNow.AddHours(1)
        };
    }
}
