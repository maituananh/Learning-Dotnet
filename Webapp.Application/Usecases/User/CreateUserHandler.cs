using Application.Commands.User;
using Application.Repository;

namespace Application.Usecases.User.CreateUserHandler;

public class CreateUserHandler
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository) 
    {
        _userRepository = userRepository;
    }

    public void Create(CreateUserCommand command)
    {
        Console.WriteLine(command);
    }
}
