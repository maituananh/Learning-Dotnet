using Application.Commands.User;
using Application.Configurations;
using Application.Repository;
using Domain;
using Application.Usecase;

namespace Application.Usecases.CreateUserHandler;

public class CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository) : IRequestHandler<CreateUserCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task Handle(CreateUserCommand command, CancellationToken ct)
    {
        var user = User.Create(command.UserName, command.Email, command.Password);

        _userRepository.Insert(user);

        await _unitOfWork.CommitAsync(ct);
    }
}
