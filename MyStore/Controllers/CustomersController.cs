using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }



        [HttpGet]
        public ActionResult<IEnumerable<CustomerModel>> Get()
        {
            var customerList = customerService.GetAllCustomers();
            return Ok(customerList);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerModel> GetCustomer(int id)
        {
            var result = customerService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerModel newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var addedCustomer = customerService.AddCustomer(newCustomer);
            return CreatedAtAction("Get", new { id = addedCustomer.Custid }, addedCustomer);
        }

        [HttpPut("{id}")]
        public ActionResult<CustomerModel> Put(int id , CustomerModel customerToUpdate)
        {
            if (id != customerToUpdate.Custid)
            {
                return BadRequest();
            }
            if (!customerService.Exists(id))
            {
                return NotFound();
            }
            var updated = customerService.UpdateCostumer(customerToUpdate);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!customerService.Exists(id))
            {
                return NotFound();
            }
            var isDeleted = customerService.Delete(id);
            return NoContent();
        }


    }
}
