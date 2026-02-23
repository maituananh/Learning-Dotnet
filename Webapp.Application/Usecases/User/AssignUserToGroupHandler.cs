using Application.Commands;
using Application.Configurations;
using Application.Usecase;
using Domain;
using Domain.Repository;

namespace Application.Usecases;

public class AssignUserToGroupHandler(
    IUnitOfWork unitOfWork,
    IGroupUserRepository groupUserRepository) :
    IRequestHandler<AssignUserToGroupCommand, GroupUser?>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IGroupUserRepository _groupUserRepository = groupUserRepository;

    public async Task<GroupUser?> Handle(AssignUserToGroupCommand command, CancellationToken ct)
    {
        var groupUserExisted = await _groupUserRepository.FindByGroupIdAndUserId(command.GroupId, command.UserId);

        var assignment = GroupUser.AssignUserToGroup(groupUserExisted, command.GroupId, command.UserId);

        _groupUserRepository.Insert(assignment);

        await _unitOfWork.CommitAsync(ct);

        return assignment;
    }
}
