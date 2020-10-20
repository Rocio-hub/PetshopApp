using Microsoft.AspNetCore.Mvc;
using PetshopApp.Core.ApplicationService;
using PetshopApp.Core.DomainService.Filtering;
using PetshopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EASV.PetshopRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController: ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/orders -- READ All
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petService.GetFilteredPets(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/orders/5 -- READ By Id
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");

            return Ok(_petService.FindPetById(id));
        }

        // POST api/orders -- CREATE
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                return Ok(_petService.CreatePet(pet));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT api/orders/5 -- Update
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.Id)
            {
                return BadRequest("Parameter Id and pet ID must be the same");
            }

            return Ok(_petService.UpdatePet(pet));
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            return Ok($"Pet with Id: {id} is Deleted");
        }
    }
}
