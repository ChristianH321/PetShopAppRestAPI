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
    public class PetsController : ControllerBase
    {
        private IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }


        // GET: api/<PetController>
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            try
            {
                if (_petService.GetPets() != null)
                {
                    return Ok(_petService.GetPets());
                }
                return NotFound();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when looking for list of pets");
            }
        }

        // GET api/<PetController>/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Id must be greater than 0");
                }
                else if (_petService.FindPetById(id) == null)
                {
                    return NotFound();
                }
                else return _petService.FindPetById(id);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when looking for a pet by ID");
            }
        }

        // POST api/<PetController>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                if (string.IsNullOrEmpty(pet.Name))
                {
                    return BadRequest("Error in Name Field. Check Name Field");
                }
                if (string.IsNullOrEmpty(pet.Color))
                {
                    return BadRequest("Error in Color Field. Check Color Field");
                }
                if (pet.Price <= 0 || pet.Price.Equals(null))
                {
                    return BadRequest("Error in Price Field. Check Price Field");
                }
                if (string.IsNullOrEmpty(pet.BirthDate.ToString()))
                {
                    return BadRequest("Error in birthdate Field. Check birthdate Field");
                }
                if (string.IsNullOrEmpty(pet.SoldDate.ToString()))
                {
                    return BadRequest("Error in solddate Field. Check solddate Field");
                }
                if (string.IsNullOrEmpty(pet.PreviousOwner))
                {
                    return BadRequest("Error in previous owner Field. Check previous owner Field");
                }
                _petService.CreatePet(pet);
                return StatusCode(201, $"Pet {pet.Name} created");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when creating pet");
            }
        }

        // PUT api/<PetController>/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            try
            {
                if (pet.ID != id || id < 0)
                {
                    return BadRequest("ID Error! Please check id");
                }
                _petService.UpdatePet(pet);
                return StatusCode(200, "Yes Sir! Pet is updated.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when updating pet");
            }
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            try
            {
                var petToDelete = _petService.DeletePet(id);
                if (petToDelete == null)
                {
                    return NotFound();
                }
                return Accepted(petToDelete);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when deleting pet");
            }
        }
    }
}
