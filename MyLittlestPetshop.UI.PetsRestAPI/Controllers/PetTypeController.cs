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
    public class PetTypeController : Controller
    {
        private readonly IPetTypeService _petTypeService;

        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PetType>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petTypeService.GetFilteredPetTypes(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<PetType> Get(int id)
        {
            if (id < 1) return BadRequest("ID must be greater than 0");
            if (_petTypeService.GetPetTypeWithId(id) == null) return BadRequest("Could not find Pet Type with that ID");
            return _petTypeService.GetPetTypeWithId(id);
        }

        [HttpPost]
        public ActionResult<PetType> Post([FromBody] PetType petType)
        {
            return _petTypeService.CreatePetType(petType);
        }

        [HttpPut("{id}")]
        public ActionResult<PetType> Put(int id, [FromBody] PetType petType)
        {
            if (id < 1 || id != petType.Id) return BadRequest("Parameter ID and Pet Type ID does not match");
            if (petType == null) return StatusCode(404, "Did not find Pet Type with ID " + id);

            return Ok(_petTypeService.UpdatePetType(petType));
        }

        [HttpDelete("{id}")]
        public ActionResult<PetType> Delete(int id)
        {
            var petType = _petTypeService.RemovePetType(id);
            if (petType == null) return StatusCode(404, "Did not find Pet Type with ID " + id);

            return Ok($"Pet Type with ID: {id} has been deleted");
        }
    }
}
