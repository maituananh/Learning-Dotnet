using Domain;
using Domain.domain;

namespace Application.Repositories;

public interface IIdentityRepository
{
    Task<User?> CheckPasswordAsync(User user);

    Task<Token> GenerateToken(User user);
}
