using Application.Commands;
using Application.Usecase;
using Domain;
using Domain.domain;
using Domain.Repositories;

namespace Application.Usecases;

public class AuthenHandler(
    IIdentityRepository identityRepository
    ) : IRequestHandler<AuthenticationCommand, Token>
{
    public async Task<Token> Handle(AuthenticationCommand command, CancellationToken ct)
    {
        var user = User.Login(command.Username, command.Password);

        var principal = await identityRepository.CheckPasswordAsync(user);

        return principal == null ?
            throw new UnauthorizedAccessException("UnauthorizedAccessException") :
            await identityRepository.GenerateToken(principal);
    }
}
