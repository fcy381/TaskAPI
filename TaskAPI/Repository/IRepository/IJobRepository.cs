using TaskAPI.Entities;

namespace TaskAPI.Repository.IRepository
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllAsync();

        Task<Job> GetAsync(Guid id);

        Task CreateAsync(Job job);

        Task UpdateAsync(Guid id, Job job);

        Task RemoveAsync(Guid id);
    }
}
