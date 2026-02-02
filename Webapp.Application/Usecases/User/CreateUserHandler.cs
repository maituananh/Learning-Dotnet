using Application.Commands.User;
using Application.Configurations;
using Application.Repository;
using Application.Usecase;
using Domain;

namespace Application.Usecases;

public class CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository) : 
    IRequestHandler<CreateUserCommand, User?>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User?> Handle(CreateUserCommand command, CancellationToken ct)
    {
        var user = User.Create(command.UserName, command.Email, command.Password);

        _userRepository.Insert(user);

        await _unitOfWork.CommitAsync(ct);

        return user;
    }
}
