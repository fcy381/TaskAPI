using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskAPI.Entities;
using TaskAPI.Repository.IRepository;

namespace TaskAPI.Repository
{
    public class JobRepository : IJobRepository
    {

        private readonly IMongoCollection<Job> _JobsCollection;

        public JobRepository(IOptions<KANBANDatabaseSettings> kanbanDatabaseSettings)
        {
            var mongoClient = new MongoClient(kanbanDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(kanbanDatabaseSettings.Value.DatabaseName);

            _JobsCollection = mongoDatabase.GetCollection<Job>(kanbanDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<Job>> GetAllAsync()
        {
            var pepe = await _JobsCollection.Find(_ => true).ToListAsync();
            return pepe;
        }

        public async Task<Job> GetAsync(Guid id)
        {
            var pepe = await _JobsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return pepe;
        }

        public async Task CreateAsync(Job job)
        {
            await _JobsCollection.InsertOneAsync(job);
        }

        public async Task UpdateAsync(Guid id, Job job)
        {
            await _JobsCollection.ReplaceOneAsync(x => x.Id == id, job);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _JobsCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
