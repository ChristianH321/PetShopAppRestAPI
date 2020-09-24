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


        // GET: api/<TypeControllerr>
        [HttpGet]
        public ActionResult<IEnumerable<PetShop.Core.Entities.Type>> Get()
        {
            try
            {
                if (_typeService.GetType() != null)
                {
                    return Ok(_typeService.GetType());
                }
                return NotFound();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when looking for list of pet types");
            }
        }

        // GET api/<TypeControllerr>/5
        [HttpGet("{id}")]
        public ActionResult<PetShop.Core.Entities.Type> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Id must be greater than 0");
                }
                else if (_typeService.FindTypeById(id) == null)
                {
                    return NotFound();
                }
                else return _typeService.FindTypeById(id);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when looking for a pet type by ID");
            }
        }

        // POST api/<TypeControllerr>
        [HttpPost]
        public ActionResult<PetShop.Core.Entities.Type> Post([FromBody] PetShop.Core.Entities.Type typeType)
        {
            try
            {
                if (string.IsNullOrEmpty(typeType.TypeType))
                {
                    BadRequest("Type Error! Check Type field.");
                }
                _typeService.CreateType(typeType);
                return StatusCode(202, "Pet Type is created.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when creating pet type");
            }
        }

        // PUT api/<TypeControllerr>/5
        [HttpPut("{id}")]
        public ActionResult<PetShop.Core.Entities.Type> Put(int id, [FromBody] PetShop.Core.Entities.Type typeType)
        {
            try
            {
                if (typeType.ID != id || id < 0)
                {
                    return BadRequest("ID Error! Please check id");
                }
                _typeService.UpdateType(typeType);
                return StatusCode(200, "Yes Sir! Pet type is updated.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when updating pet type");
            }
        }

        // DELETE api/<TypeControllerr>/5
        [HttpDelete("{id}")]
        public ActionResult<PetShop.Core.Entities.Type> Delete(int id)
        {
            try
            {
                var typeToDelete = _typeService.DeleteType(id);
                if (typeToDelete == null)
                {
                    return NotFound();
                }
                return Accepted(typeToDelete);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when deleting pet type");
            }
        }
    }
}
