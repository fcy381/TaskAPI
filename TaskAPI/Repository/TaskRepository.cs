using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskAPI.Entities;
using TaskAPI.Repository.IRepository;

namespace TaskAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {

        private readonly IMongoCollection<Entities.Tarea> _tareasCollection;

        public TaskRepository(IOptions<KANBANDatabaseSettings> kanbanDatabaseSettings)
        {
            var mongoClient = new MongoClient(kanbanDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(kanbanDatabaseSettings.Value.DatabaseName);

            _tareasCollection = mongoDatabase.GetCollection<Entities.Tarea>(kanbanDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<Entities.Tarea>> GetAllAsync()
        {
            var pepe = await _tareasCollection.Find(_ => true).ToListAsync();
            return pepe;
        }

        public async Task<Entities.Tarea> GetAsync(Guid id)
        {
            var pepe = await _tareasCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return pepe;
        }

        public async Task CreateAsync(Entities.Tarea task)
        {
            await _tareasCollection.InsertOneAsync(task);
        }

        public async Task UpdateAsync(Guid id, Entities.Tarea task)
        {
            await _tareasCollection.ReplaceOneAsync(x => x.Id == id, task);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _tareasCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task SaveAsync()
        {

        }
    }
}
