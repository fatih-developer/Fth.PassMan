using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Business.Abstract;
using QRCoder;
using System.Drawing.Imaging;
using Core.Utilities.Security.Hashing;
using Entities.Concrete.MongoDb;
using PassMan.UI.Models;
using static QRCoder.QRCodeGenerator;

namespace PassMan.UI.Controllers
{
    public class PasswordController : Controller
    {
        private IPasswordService _passwordService;

        System.Timers.Timer _timer;

        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        public IActionResult Index()
        {
            List<string> _categoryList = new List<string>();
            List<string> _brandList = new List<string>();

            _categoryList.Add("Seçiniz");
            _categoryList.Add("Database");
            _categoryList.Add("Rdp");
            _categoryList.Add("Ssh");

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

            return View("Add",model);
        }


        public byte[] CreateQRCode(string code)
        {
            QRCodeGenerator QrGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode QrCode = new QRCode(QrCodeInfo);
            Bitmap QrBitmap = QrCode.GetGraphic(20);
            byte[] BitmapArray = QrBitmap.BitmapToByteArray();
            //string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
            //ViewBag.QrCodeUri = QrUri;
            return BitmapArray;
        }

      

        [HttpPost]
        public ActionResult Add(Passwords password)
        {

            password.Id = String.Empty;
            password.SecretKey = "8UHjPgXZzXCGkhxV2QCnooyJexUzvJrO";

            _passwordService.CreateNewPasswordAsync(password);
            //ViewBag.Durum("message", "Product was successfully added");

            return RedirectToAction(actionName:"Index",controllerName:"Home");
        }

        public IActionResult Details(string id, bool visible= false)
        {
            PassShowViewModel model;

            var passData = _passwordService.GetByIdAsync(id).Result;
            var imageData = CreateQRCode(passData.Password);
            

            if (visible)
            {
                model = new PassShowViewModel
                {
                    Passwords = passData,
                    imageData = imageData,
                };

                var secretData = CryptoHelper.Decrypt(passData.Password, "8UHjPgXZzXCGkhxV2QCnooyJexUzvJrO");
                model.Pass = secretData;


                _timer = new System.Timers.Timer(1000);
                _timer.Elapsed += (sender, e) => timer_Tick(id);
                _timer.Start();
            }
            else
            {
                model = new PassShowViewModel
                {
                    Passwords = passData,
                    imageData = imageData,
                    Pass = String.Empty
                };
            }
            return View(model);
        }
        private void timer_Tick(string id)
        {
            for (int i = 0; i < 10; i++)
            {

            }
            _timer.Stop();
            Details(id, false);

        }
    }

    public static class BitmapExtension
    {
        public static byte[] BitmapToByteArray(this Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
