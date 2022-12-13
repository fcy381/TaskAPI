using TaskAPI.Repository.IRepository;

namespace TaskAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {

        Task<ICollection<Entities.Task>> GetAllAsync()
        { 
            
        }

        Task<Entities.Task> GetAsync(int id)
        {

        }

        Task CreateAsync()
        {

        }

        Task UpdateAsync(int id)
        {

        }

        Task RemoveAsync(int id)
        {

        }

        Task SaveAsync()
        {

        }

        Task<ICollection<Entities.Task>> ITaskRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Entities.Task> ITaskRepository.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task ITaskRepository.CreateAsync()
        {
            throw new NotImplementedException();
        }

        Task ITaskRepository.UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task ITaskRepository.RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task ITaskRepository.SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
