using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            try
            {
                if (_customerService.GetCustomer() != null)
                {
                    return Ok(_customerService.GetCustomer());
                }
                return NotFound();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when looking for list of customer");
            }
        }


        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Id must be greater than 0");
                }
                else if (_customerService.FindCustomerById(id) == null)
                {
                    return NotFound();
                }
                else return _customerService.FindCustomerById(id);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when looking for a customer by ID");
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            try
            {
                if (string.IsNullOrEmpty(customer.FirstName))
                {
                    return BadRequest("First Name Error! Check FirstName field.");
                }
                if (string.IsNullOrEmpty(customer.LastName))
                {
                    return BadRequest("Last Name Error! Check SecondName field.");
                }
                if (string.IsNullOrEmpty(customer.BirthDateOfCustomer.ToString()))
                {
                    return BadRequest("Birthdate Error! Check birthdate field.");
                }
                if (string.IsNullOrEmpty(customer.Adress))
                {
                    return BadRequest("Adress Error! Check Adress field");
                }

                _customerService.CreateCustomer(customer);
                return StatusCode(201, "Customer is created.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when creating customer");
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
        {
            try
            {
                if (customer.ID != id || id < 0)
                {
                    return BadRequest("ID Error! Please check id");
                }
                _customerService.UpdateCustomer(customer);
                return StatusCode(200, "Customer is updated.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when updating customer");
            }
        }

        // DELETE api/< CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            try
            {
                var customerToDelete = _customerService.DeleteCustomer(id);
                if (customerToDelete == null)
                {
                    return NotFound();
                }
                return Accepted(customerToDelete);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when deleting customer");
            }
        }
    }
}
