using Application.Usecase;
using Domain;
using Domain.Repository;

namespace Application.Usecases;

public class GetGroupByIdHandler : IRequestHandler<Guid, Group?>
{
    private readonly IGroupRepository _groupRepository;

    public GetGroupByIdHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<Group?> Handle(Guid groupId, CancellationToken ct)
    {
        return await _groupRepository.GetById(new Domain.Group(groupId));
    }
}
