using Domain.domain;

namespace Domain.Repositories;

public interface IIdentityRepository
{
    Task<User?> CheckPasswordAsync(User user);

    Task<Token> GenerateToken(User user);
}
