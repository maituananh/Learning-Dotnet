using Application.Usecase;

namespace Application.Usecases.Group;

public class GetGroupByIdHandler : IRequestHandler<Guid>
{
    public Task Handle(Guid groupId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
