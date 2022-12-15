namespace TaskAPI.Repository.IRepository
{
    public interface ITaskRepository
    {
        Task<List<Entities.Tarea>> GetAllAsync();

        Task<Entities.Tarea> GetAsync(Guid id);

        Task CreateAsync(Entities.Tarea task);

        Task UpdateAsync(Guid id, Entities.Tarea task);

        Task RemoveAsync(Guid id);

        Task SaveAsync();
    }
}
