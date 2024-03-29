﻿using Entities.Concrete;
using Entities.Concrete.MongoDb;

namespace Business.Abstract;

public interface IPasswordService
{
    Task<List<Passwords>> GetAllAsync();
    Task<Passwords> GetByIdAsync(string id);
    Task CreateNewPasswordAsync(Passwords newPass);
    Task UpdatePassAsync(Passwords passToUpdate);
    Task DeletePassAsync(string id);
    string GetPasswordsByVisible(string password, string key);
}