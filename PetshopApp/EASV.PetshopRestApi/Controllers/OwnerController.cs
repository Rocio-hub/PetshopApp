using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EASV.PetshopRestApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetshopApp.Core.ApplicationService;
using PetshopApp.Core.DomainService.Filtering;
using PetshopApp.Core.Entity;

namespace EASV.PetshopRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET api/customers -- READ All
        [HttpGet]
        public ActionResult<FilteredList<OwnerDto>> Get([FromQuery] Filter filter)
        {
            try
            {
                if (filter.CurrentPage == 0 && filter.ItemsPrPage == 0)
                {
                    var list = _ownerService.GetAllOwners(null);
                    var newList = new List<OwnerDto>();
                    foreach (var owner in list.List)
                    {
                        newList.Add(new OwnerDto()
                        {
                            Id = owner.Id,
                            FirstName = owner.FirstName,
                            LastName = owner.LastName
                        });
                    }
                    var newFilteredList = new FilteredList<OwnerDto>();
                    newFilteredList.List = newList;
                    newFilteredList.Count = list.Count;
                    return Ok(newFilteredList);
                }
                return Ok(_ownerService.GetAllOwners(filter));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        // GET api/customers/5 -- READ By Id
        [HttpGet("{id}")]
        public ActionResult<OwnerDto> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");

            //return _ownerService.FindOwnerById(id);
            var coreOwner = _ownerService.FindOwnerByIdIncludePets(id);
            return new OwnerDto()
            {
                Id = coreOwner.Id,
                FirstName = coreOwner.FirstName,
                LastName = coreOwner.LastName
            };
        }

        // POST api/customers -- CREATE JSON
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.FirstName))
            {
                return BadRequest("Firstname is Required for Creating Owner");
            }

            if (string.IsNullOrEmpty(owner.LastName))
            {
                return BadRequest("LastName is Required for Creating Owner");
            }
            //return StatusCode(503, "Horrible Error CALL Tech Support");
            return _ownerService.CreateOwner(owner);
        }

        // PUT api/customers/5 -- Update
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.Id)
            {
                return BadRequest("Parameter Id and owner ID must be the same");
            }

            return Ok(_ownerService.UpdateOwner(owner));
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var owner = _ownerService.DeleteOwnerById(id);
            if (owner == null)
            {
                return StatusCode(404, "Did not find Owner with ID " + id);
            }

            return NoContent();
        }
    }
}

