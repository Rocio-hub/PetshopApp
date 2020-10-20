using Microsoft.AspNetCore.Mvc;
using PetshopApp.Core.ApplicationService;
using PetshopApp.Core.DomainService.Filtering;
using PetshopApp.Core.Entity;
using System;
using System.Collections.Generic;

namespace EASV.PetshopRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypeController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetTypeController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/customers -- READ All
        [HttpGet]
        public ActionResult<List<PetType>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petService.ReadPetTypes());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
