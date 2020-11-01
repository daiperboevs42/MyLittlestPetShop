using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLittlestPetShop.Core.AppService;
using MyLittlestPetShop.Core.Entity;

namespace MyLittlestPetshop.UI.PetsRestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petService.GetFilteredPets(filter));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1) return BadRequest("ID must be greater than 0");
            if (_petService.GetPetWithId(id) == null) return BadRequest("Could not find Pet with that ID");
            return _petService.GetPetWithId(id);
        }

        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                return Ok(_petService.CreatePet(pet));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.Id) return BadRequest("Parameter ID and PetID does not match");
            
            return Ok(_petService.UpdatePetAPI(pet));
        }

        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var pet = _petService.RemovePet(id);
            if (pet == null) return StatusCode(404, "Did not find Pet with ID " + id);
            
            return Ok($"Pet with ID: {id} has been deleted");
        }
    }
}
