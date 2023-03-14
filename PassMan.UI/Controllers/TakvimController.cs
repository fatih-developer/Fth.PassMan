using Business.Abstract;
using Entities.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PassMan.UI.Controllers
{
    public class TakvimController : Controller
    {
        private ICalendarService _calendarService;

        public TakvimController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        public IActionResult Index()
        {
            var model = new CalendarListViewModel
            {
                calendar = _calendarService.GetAll()
            };

            return View(model);
        }


        public IActionResult Add()
        {
            var model = new CalendarAddViewModel
            {
                Calendar = new Calendar(),
                
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Calendar calendar)
        {

            if (ModelState.IsValid)
            {
                _calendarService.Add(calendar);
            }

            return RedirectToAction("Index");
        }
    }
}
