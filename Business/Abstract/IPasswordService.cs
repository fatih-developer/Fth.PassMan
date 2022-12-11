using Entities.Concrete;

namespace Business.Abstract;

public interface IPasswordService
{
    Task<List<Passwords>> GetAllAsync();
    Task<Passwords> GetByIdAsync(string id);
    Task CreateNewPasswordAsync(Passwords newPass);
    Task UpdatePassAsync(Passwords passToUpdate);
    Task DeletePassAsync(string id);
}