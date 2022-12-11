using Entities.Concrete;

namespace DataAccess.Concrete.Mongo.Repositories
{
    public interface IPasswordRepository
    {
        Task<List<Passwords>> GetAllAsync();

        Task<Passwords> GetByIdAsync(string id);
        Task CreateNewPasswordAsync(Passwords newPass);
        Task UpdatePassAsync(Passwords passToUpdate);
        Task DeletePassAsync(string id);
    }
}