using Application.Usecase;
using Domain;
using Domain.Repository;

namespace Webapp.Application.Usecases;

public class GetUserHandler(IUserRepository userRepository) : IRequestHandler<Guid, User?>
{
    public async Task<User?> Handle(Guid id, CancellationToken ct)
    {
        return await userRepository.GetById(new User(id));
    }
}
