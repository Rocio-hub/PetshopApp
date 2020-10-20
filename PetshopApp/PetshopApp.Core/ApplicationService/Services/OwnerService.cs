using PetshopApp.Core.DomainService;
using PetshopApp.Core.DomainService.Filtering;
using PetshopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopApp.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;
        readonly IPetRepository _petRepo;

        public int Count()
        {
            return _ownerRepo.Count();
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepo.CreateOwner(owner);
        }

        public Owner DeleteOwnerById(int id)
        {
            return _ownerRepo.DeleteOwnerById(id);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepo.ReadyById(id);
        }

        public Owner FindOwnerByIdIncludePets(int id)
        {
            return _ownerRepo.ReadyByIdIncludePets(id);
        }

        public FilteredList<Owner> GetAllOwners(Filter filter)
        {
            return _ownerRepo.ReadAll(filter);
        }

        public Owner NewOwner(string firstName, string lastName)
        {
            var newOwner = new Owner()
            {
                FirstName = firstName,
                LastName = lastName,
            };
            return newOwner;
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            return _ownerRepo.Update(ownerUpdate);
        }
    }
}
