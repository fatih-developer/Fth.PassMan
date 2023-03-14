using Entities.Concrete;
using Entities.Concrete.MongoDb;
using MongoDB.Driver;

namespace DataAccess.Concrete.Mongo.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly IMongoCollection<Passwords> _passwordCollection;

        public PasswordRepository(IMongoDatabase mongoDatabase)
        {
            _passwordCollection = mongoDatabase.GetCollection<Passwords>("passwords");
        }

        public async Task CreateNewPasswordAsync(Passwords newPass)
        {
            await _passwordCollection.InsertOneAsync(newPass);
        }

        public async Task<List<Passwords>> GetAllAsync()
        {
            return await _passwordCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Passwords> GetByIdAsync(string id)
        {
            return await _passwordCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdatePassAsync(Passwords passToUpdate)
        {
            await _passwordCollection.ReplaceOneAsync(x => x.Id == passToUpdate.Id, passToUpdate);
        }

        public async Task DeletePassAsync(string id)
        {
            await _passwordCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
