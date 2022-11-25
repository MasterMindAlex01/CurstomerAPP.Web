using Microsoft.AspNetCore.Mvc;
using CurstomerAPP.Interfaces;
using CustomerAPP.Models;

namespace CurstomerAPP.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: Customers
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            List<CustomerModel> customersList = new List<CustomerModel>();
            var result = await _customerService.GetCustomersListAsync();
            if (!result.IsSuccess)
            {
                return PartialView("_List",customersList);
            }
            customersList = (List<CustomerModel>)result.Object;
            return PartialView("_List", customersList);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Create",model);
            }

            var result = await _customerService.CreateCustomerAsync(model);
            return Json(result);

        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerModel customer = new CustomerModel();
            var result = await _customerService.GetCustomerByIdAsync(id.Value);
            if (!result.IsSuccess)
            {
                return PartialView("_Edit", customer);
            }
            customer = (CustomerModel)result.Object;
            return PartialView("_Edit", customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Edit", model);
            }

            var result = await _customerService.UpdateCustomerAsync(model);
            return Json(result);

        }


        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _customerService.DeleteCustomerAsync(id.Value);
            return Json(result);
        }

    }
}
