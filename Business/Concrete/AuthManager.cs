using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Entities.ComplexTypes;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete;

public class AuthManager:IAuthService
{
    private UserManager<User> _userManager;
    private RoleManager<Member> _roleManager;
    private SignInManager<User> _signInManager;

    public AuthManager(UserManager<User> userManager, RoleManager<Member> roleManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }


    public async Task<IdentityResult> UserCreateAsync(User user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        return result;
    }

    public async Task<IdentityResult> RoleCreateAsync(Member role)
    {
        var result = await _roleManager.CreateAsync(role);
        return result;
    }

    
    public IList<User> GetUsersInRoleAsync(string role)
    {
        var result = _userManager.GetUsersInRoleAsync(role).Result;
        return result;

    }

    public async Task<bool> RoleExistsAsync(string role)
    {
        var result = await _roleManager.RoleExistsAsync(role);
        return result;
    }

    public async Task<IdentityResult> AddToRoleAsync(User user, string role)
    {
        var result = await _userManager.AddToRoleAsync(user, "Admin");
        return result;
    }

    //public IDataResult<UserDetailDto> Login(UserLoginDto userLoginDto)
    //{
    //    var userToCheck = _signInManager.PasswordSignInAsync(userLoginDto.Username,userLoginDto.Password,true,false);
        

    //    //if (userToCheck == null)
    //    //{
    //    //    return new ErrorDataResult<UserDetailDto>(Messages.AuthError);
    //    //}

    //    //var loginOk = _ldapTools.ValidateCredentials(userLoginDto.Username, userLoginDto.Password);
    //    //if (loginOk)
    //    //{
    //    //    return new SuccessDataResult<UserDetailDto>(userToCheck.Data, Messages.SuccessfulLogin);
    //    //}
    //    //return new ErrorDataResult<UserDetailDto>(Messages.UserPassError);
    //}
}