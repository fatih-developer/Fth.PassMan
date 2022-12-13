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
            List<string> _categoryList = new List<string>();
            List<string> _brandList = new List<string>();

            _categoryList.Add("Seçiniz...");
            _categoryList.Add("database");
            _categoryList.Add("rdp");
            _categoryList.Add("ssh");

            _brandList.Add("Seçiniz...");
            _brandList.Add("Oracle");
            _brandList.Add("Windows");
            _brandList.Add("Linux");
            _brandList.Add("Domain");
            _brandList.Add("Google");
            _brandList.Add("Fortinet");

            var model = new PasswordSaveModel
            {
                Password = new Passwords(),
                Categories = _categoryList,
                Clients = _brandList
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult Add(Passwords password)
        {

            password.Id = String.Empty;

            _passwordService.CreateNewPasswordAsync(password);
            ViewBag.Durum("message", "Product was successfully added");

            return RedirectToAction("Index");
        }

        public IActionResult Details()
        {
            throw new NotImplementedException();
        }
    }
}
