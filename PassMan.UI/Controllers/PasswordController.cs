using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Business.Abstract;

namespace PassMan.UI.Controllers
{
    public class PasswordController : Controller
    {
        private IPasswordService _passwordService;

        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        public IActionResult Index()
        {
            var model = new PasswordSaveModel
            {
                Password = new Passwords()
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult Add(Passwords password)
        {
            password.iv = "asdklasjdolasjdl";
            password.Id = String.Empty;
            
            _passwordService.CreateNewPasswordAsync(password);
            TempData.Add("message", "Product was successfully added");

            return RedirectToAction("Index");
        }

    }
}
