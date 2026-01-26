namespace Application.Repository;

public interface IUserRepository
{
    public Task Save();
    
    public Task Delete();

    public Task Update();

    public Task FindByID(Guid id);
}
