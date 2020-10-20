using PetshopApp.Core.DomainService.Filtering;
using PetshopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopApp.Core.ApplicationService
{
    public interface IOwnerService
    {
        //New Owner
        Owner NewOwner(string firstName, string lastName);

        //Create //POST
        Owner CreateOwner(Owner owner);

        //Read //GET
        Owner FindOwnerById(int id);
        Owner FindOwnerByIdIncludePets(int id);

        FilteredList<Owner> GetAllOwners(Filter filter);
        int Count();

        //Update //PUT
        Owner UpdateOwner(Owner ownerUpdate);

        //Delete //DELETE
        Owner DeleteOwnerById(int id);
    }
}
