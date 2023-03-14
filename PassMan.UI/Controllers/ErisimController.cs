using Business.Abstract;
using Entities.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PassMan.UI.Controllers
{
    public class ErisimController : Controller
    {

        IConnectionService _connectionService;

        public ErisimController(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Add()
        {
            var model = new ConnectionAddViewModel
            {
                Connection = new Connection(),

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Connection connection)
        {

            if (ModelState.IsValid)
            {
                _connectionService.Add(connection);
            }

            return RedirectToAction("Index");
        }
    }
}
