namespace TaskAPI.Repository.IRepository
{
    public interface ITaskRepository
    {
        Task<ICollection<Entities.Task>> GetAllAsync();

        Task<Entities.Task> GetAsync(int id);

        Task CreateAsync();

        Task UpdateAsync(int id);

        Task RemoveAsync(int id);

        Task SaveAsync();
    }
}
