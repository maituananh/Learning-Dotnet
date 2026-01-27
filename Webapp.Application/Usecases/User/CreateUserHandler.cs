using Application.Commands.User;
using Application.Configurations;
using Application.Repository;
using Domain;

namespace Application.Usecases.CreateUserHandler;

public class CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
{

    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task Create(CreateUserCommand command)
    {
        User user = new(command.UserName, command.Email, command.Password);
        await _userRepository.Insert(user);
        await _unitOfWork.CommitAsync();
    }
}
