using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace Business.Abstract;

public interface IAuthService
{
    Task<IdentityResult> UserCreateAsync(User user, string password);

    Task<IdentityResult> RoleCreateAsync(Member role);

    IList<User> GetUsersInRoleAsync(string role);

    Task<bool> RoleExistsAsync(string role);

    Task<IdentityResult> AddToRoleAsync(User user,string role);

    Task<SignInResult> PasswordSignInAsync(string username, string password, bool RememberMe);

}