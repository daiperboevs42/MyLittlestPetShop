using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLittlestPetShop.Core.AppService;
using MyLittlestPetShop.Core.Entity;

using Microsoft.AspNetCore.Authorization; //for authorization and login
using MyLittlestPetShop.Core.DataService;

namespace MyLittlestPetshop.UI.PetsRestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        //[Authorize(Roles = "Administator")] //means this method needs authorization
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get([FromQuery] Filter filter)
        {
            try
            {
                System.Console.WriteLine("WHAT YOU SEE HERE IS  " + filter.CurrentPage + "      " + filter.ItemsPrPage);
                return Ok(_ownerService.GetFilteredOwners(filter));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[Authorize(Roles = "Administator")] //means this method needs authorization
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1) return BadRequest("ID must be greater than 0");
            if(_ownerService.FindOwnerById(id) == null) return BadRequest("Could not find Owner with that ID");
            return _ownerService.FindOwnerById(id);
        }

        [HttpPost]
        public void Post([FromBody] Owner owner)
        {
            _ownerService.CreateOwner(owner);
        }

        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.Id) return BadRequest("Parameter ID and Owner ID does not match");
            if (owner == null) return StatusCode(404, "Did not find Owner with ID " + id);
            return Ok(_ownerService.UpdateOwner(owner));
        }
        
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var owner = _ownerService.DeleteOwner(id);
            if (id < 1 || id != owner.Id) return BadRequest("Parameter ID and Owner ID does not match");
            if (owner == null) return StatusCode(404, "Did not find Owner with ID " + id);
            
            return Ok($"Owner with ID: {id} has been deleted");
        }
    }
}
