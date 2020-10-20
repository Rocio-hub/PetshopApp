using PetshopApp.Core.DomainService.Filtering;
using PetshopApp.Core.Entity;
using System.Collections.Generic;

namespace PetshopApp.Core.DomainService
{
    public interface IPetRepository
    {
        //Create Data
        //No Id when enter, but Id when exits
        Pet Create(Pet pet);

        //Read Data
        Pet ReadyById(int id);
        FilteredList<Pet> ReadAll(Filter filter = null);
        List<PetType> ReadPetTypes();
        int Count();


        //Update Data
        Pet Update(Pet petUpdate);

        //Delete Data
        Pet DeleteById(int id);
    }
}
