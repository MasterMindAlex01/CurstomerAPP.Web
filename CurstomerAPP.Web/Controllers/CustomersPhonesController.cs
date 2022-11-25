using Microsoft.AspNetCore.Mvc;
using CustomerAPP.Models;
using CurstomerAPP.Interfaces;

namespace CurstomerAPP.Web.Controllers
{
    public class CustomersPhonesController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersPhonesController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: CustomersPhones
        public async Task<IActionResult> Index()
        {
            var modelList = new List<CustomersPhoneModel>();
            var result = await _customerService.GetCustomerPhonesListAsync();
            if (!result.IsSuccess)
            {
                return View(modelList);
            }
            modelList = (List<CustomersPhoneModel>)result.Object;
            return View(modelList);
        }

        // GET: CustomersPhones/Create
        public IActionResult Create(int cId)
        {
            //ViewData["CId"] = new SelectList(_context.Customers, "CId", "CLastName1");
            var model = new CustomersPhoneModel();
            model.CId = cId;
            return PartialView("_Create", model);
        }

        // POST: CustomersPhones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomersPhoneModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Create", model);
            }
            var result = await _customerService.CreateCustomerPhoneAsync(model);
            return Json(result);
        }

        public async Task<IActionResult> Details(int cId)
        {
            var modelList = new List<CustomersPhoneModel>();
            var result = await _customerService.GetLastCustomerPhonesByCustomerIdAsync(cId);
            if (!result.IsSuccess)
            {
                return PartialView("_Details", modelList);
            }
            modelList = (List<CustomersPhoneModel>)result.Object;
            return PartialView("_Details", modelList);
        }

        // GET: CustomersPhones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = new CustomersPhoneModel();
            var result = await _customerService.GetCustomerPhoneByIdAsync(id.Value);
            if (!result.IsSuccess)
            {
                return PartialView("_Edit", model);
            }
            model = (CustomersPhoneModel)result.Object;
            return PartialView("_Edit", model);
        }

        // POST: CustomersPhones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomersPhoneModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Edit", model);
            }
            var result = await _customerService.UpdateCustomerPhoneAsync(model);
            return Json(result);
        }

        // POST: CustomersPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _customerService.DeleteCustomerPhoneAsync(id.Value);
            return Json(result);
        }

    }
}
