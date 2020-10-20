using PetshopApp.Core.DomainService;
using PetshopApp.Core.DomainService.Filtering;
using PetshopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PetshopApp.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepo;
        readonly IOwnerRepository _ownerRepo;

        public Pet CreatePet(Pet pet)
        {
            if (pet.Owner == null || pet.Owner.Id <= 0)
                throw new InvalidDataException("To create Pet you need an Owner");
            if (_ownerRepo.ReadyById(pet.Owner.Id) == null)
                throw new InvalidDataException("Owner Not found");
            if (pet.PetName == null)
                throw new InvalidDataException("Pet needs a Pet name");
            //if (pet.DeliveryDate <= DateTime.MinValue)
            //    throw new InvalidDataException("To create Order you need a deliveryDate");
            return _petRepo.Create(pet);
        }

        public Pet DeletePet(int id)
        {
            return _petRepo.DeleteById(id);
        }

        public Pet FindPetById(int id)
        {
            return _petRepo.ReadyById(id);
        }

        public FilteredList<Pet> GetAll()
        {
            return _petRepo.ReadAll();
        }

        public FilteredList<Pet> GetFilteredPets(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage and ItemsPage Must zero or more");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _petRepo.Count())
            {
                throw new InvalidDataException("Index out bounds, CurrentPage is to high");
            }

            if (filter == null || (filter.ItemsPrPage == 0 && filter.CurrentPage == 0))
            {
                return GetAll();
            }

            return _petRepo.ReadAll(filter);
        }

        public Pet New()
        {
            return new Pet();
        }

        public List<PetType> ReadPetTypes()
        {
            return _petRepo.ReadPetTypes();
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            return _petRepo.Update(petUpdate);
        }
    }
}
