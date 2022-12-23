using Microsoft.AspNetCore.Mvc;
using PassMan.UI.Models;
using System.Diagnostics;
using Business.Abstract;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using QRCoder;
using System.Drawing;

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
            var passList = _passwordService.GetAllAsync().Result;
            PassShowViewModel passShowViewModel;
            List<PassShowViewModel> modelList = new List<PassShowViewModel>();


            foreach (var pl in passList)
            {
                passShowViewModel = new PassShowViewModel
                {
                    imageData = CreateQRCode(pl.Password),
                    Passwords = pl
                };
                modelList.Add(passShowViewModel);

            }


            var model = new PasswordListViewModel
            {
                ListPassword = modelList
            };


            return View(model);
        }


        public string Visible(string secret,string key)
        {
            var data = _passwordService.GetPasswordsByVisible(secret,key);
            return data;
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

    }
}