using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PassMan.UI.Models;

namespace PassMan.UI.Controllers
{
    public class AuthController : Controller
    {
        private UserManager<User> _userManager;
        private RoleManager<Member> _roleManager;
        private SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, RoleManager<Member> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    FullName = registerViewModel.FirstName + " " + registerViewModel.LastName
                };

                IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result;

                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("Admin").Result)
                    {
                        Member role = new Member
                        {
                            Name = "Admin"
                        };

                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                        if (!roleResult.Succeeded)
                        {
                            TempData.Add("message", "");
                            ModelState.AddModelError("", "We cant add the role!");
                            return View(registerViewModel);
                        }

                    }

                    var adminUser = _userManager.GetUsersInRoleAsync("Normal").Result;
                    if (adminUser.Count > 0)
                    {
                        if (!_roleManager.RoleExistsAsync("Normal").Result)
                        {
                            Member role = new Member
                            {
                                Name = "Normal"
                            };

                            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                            if (!roleResult.Succeeded)
                            {
                                TempData.Add("message", "");
                                ModelState.AddModelError("", "We cant add the role!");
                                return View(registerViewModel);
                            }

                        }
                        _userManager.AddToRoleAsync(user, "Admin").Wait();
                    }
                    else
                    {
                        _userManager.AddToRoleAsync(user, "Normal").Wait();
                    }

                    //_userManager.AddToRoleAsync(user, "Normal").Wait();
                    return RedirectToAction("Login", "Auth");
                }

                TempData.Add("message", "Hata Şifreniz kurallara uygun değildir.");

            }
            return View(registerViewModel);
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [LogAspect(typeof(FileLogger))]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(loginViewModel.UserName,
                    loginViewModel.Password, loginViewModel.RememberMe, false).Result;



                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login!");
            }

            return View(loginViewModel);
        }



       

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }



        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordModel.Password);

            ViewBag.Message = "Şifreniz Değiştirilmiştir.";
            return View("Login");
        }

        
    }
}
