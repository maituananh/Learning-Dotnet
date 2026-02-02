namespace Application.Usecase;

internal interface IRequestHandler<T, TResult>
{
    Task<TResult> Handle(T command, CancellationToken ct);
}
