using Microsoft.AspNetCore.Mvc;
using PassMan.UI.Models;
using System.Diagnostics;
using Business.Abstract;

namespace PassMan.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IPasswordService _passwordService;

        public HomeController(ILogger<HomeController> logger, IPasswordService passwordService)
        {
            _logger = logger;
            _passwordService = passwordService;
        }

        public IActionResult Index()
        {
            var model = new PasswordListViewModel
            {
                ListPassword = _passwordService.GetAllAsync().Result
            };


            return View(model);
        }

       
    }
}