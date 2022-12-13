using Business.Abstract;
using Core.Utilities.Security.Hashing;
using DataAccess.Concrete.Mongo.Repositories;
using Entities.Concrete;

namespace Business.Concrete;

public class PasswordManager:IPasswordService
{
    private readonly IPasswordRepository _passwordRepository;

    public PasswordManager(IPasswordRepository passwordRepository)
    {
        _passwordRepository = passwordRepository;
    }

    public async Task<List<Passwords>> GetAllAsync()
    {
        return await _passwordRepository.GetAllAsync();
    }

    public async Task<Passwords> GetByIdAsync(string id)
    {
        return await _passwordRepository.GetByIdAsync(id);
    }

    public Task CreateNewPasswordAsync(Passwords newPass)
    {
        newPass.Password = EncryptionHelper.EncryptString(newPass.Password);
        return  _passwordRepository.CreateNewPasswordAsync(newPass);
    }

    public Task UpdatePassAsync(Passwords passToUpdate)
    {
        return _passwordRepository.UpdatePassAsync(passToUpdate);
    }

    public Task DeletePassAsync(string id)
    {
        return (_passwordRepository.DeletePassAsync(id));
    }
}