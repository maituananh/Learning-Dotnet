using Application.Commands;
using Application.Configurations;
using Application.Repository;
using Application.Usecase;
using Domain;

namespace Application.Usecases;

public class CreateUserHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork) :
    IRequestHandler<CreateUserCommand, User?>
{
    public async Task<User?> Handle(CreateUserCommand command, CancellationToken ct)
    {
        await unitOfWork.BeginTransactionAsync(ct);

        try
        {
            var user = User.Create(command.UserName, command.Email, command.Password);
            await userRepository.Insert(user);
            await unitOfWork.CommitAsync(ct);

            return user;
        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync(ct);
            throw new Exception("Error creating user", ex);
        }
    }
}
