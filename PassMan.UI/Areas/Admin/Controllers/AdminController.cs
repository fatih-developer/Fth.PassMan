using Microsoft.AspNetCore.Mvc;

namespace PassMan.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
