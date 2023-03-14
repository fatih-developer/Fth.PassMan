using Business.Abstract;
using Entities.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using PassMan.UI.Models;

namespace PassMan.UI.Controllers
{
    
    public class MusteriController : Controller
    {
        ICustomerService _customerService;

        public MusteriController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var model = new CustomerListViewModel
            {
                customer = _customerService.GetAll()
            };

            return View(model);
        }


        public IActionResult Add()
        {
            var model = new CustomerAddViewModel
            {
                Customer = new Customer(),

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Customer customer)
        {

            if (ModelState.IsValid)
            {
                _customerService.Add(customer);
            }

            return RedirectToAction("Index");
        }
    }
}
