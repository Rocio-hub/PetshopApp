using PetshopApp.Core.DomainService.Filtering;
using PetshopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopApp.Core.ApplicationService
{
    public interface IPetService
    {
        //New Pet
        Pet New();

        //Create //POST
        Pet CreatePet(Pet pet);

        //Read //GET
        Pet FindPetById(int id);
        FilteredList<Pet> GetAll();
        FilteredList<Pet> GetFilteredPets(Filter filter);
        List<PetType> ReadPetTypes();

        //Update //PUT
        Pet UpdatePet(Pet petUpdate);

        //Delete //DELETE
        Pet DeletePet(int id);
        
    }
}
