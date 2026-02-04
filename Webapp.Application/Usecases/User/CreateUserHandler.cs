using Application.Commands;
using Application.Repository;
using Application.Usecase;
using Domain;

namespace Application.Usecases;

public class CreateUserHandler(IUserRepository userRepository) :
    IRequestHandler<CreateUserCommand, User?>
{
    public async Task<User?> Handle(CreateUserCommand command, CancellationToken ct)
    {
        var user = User.Create(command.UserName, command.Email, command.Password);

        await userRepository.Insert(user);

        return user;
    }
}
