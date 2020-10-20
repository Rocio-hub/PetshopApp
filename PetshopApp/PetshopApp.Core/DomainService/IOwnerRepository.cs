using PetshopApp.Core.DomainService.Filtering;
using PetshopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopApp.Core.DomainService
{
    public interface IOwnerRepository
    {
        //OwnerRepository Interface
        
        //Create Data
        //No Id when enter, but Id when exits
        Owner CreateOwner(Owner owner);
       
        //Read Data
        Owner ReadyById(int id);
        FilteredList<Owner> ReadAll(Filter filter);
        int Count();
        
        //Update Data
        Owner Update(Owner ownerUpdate);
        
        //Delete Data
        Owner DeleteOwnerById(int id);
        Owner ReadyByIdIncludePets(int id);
    }
}
