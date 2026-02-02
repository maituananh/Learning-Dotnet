namespace Application.Usecase;

internal interface IRequestHandler<T>
{
    Task Handle(T command, CancellationToken ct);
}
