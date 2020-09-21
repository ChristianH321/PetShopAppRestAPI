using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;

using PetShop.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }
  
        // GET: api/<TypeController>
        [HttpGet]
        public IEnumerable<PetShop.Core.Entities.Type> Get()
        {
            return _typeService.GetTypes();
        }

        // GET api/<TypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "None";
            //return _typeService.GetType(id);
        }

        // POST api/<TypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
