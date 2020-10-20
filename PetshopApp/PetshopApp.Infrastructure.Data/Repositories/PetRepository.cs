using Microsoft.EntityFrameworkCore;
using PetshopApp.Core.DomainService;
using PetshopApp.Core.DomainService.Filtering;
using PetshopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetshopApp.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        readonly PetshopAppContext _ctx;

        public PetRepository(PetshopAppContext ctx)
        {
            _ctx = ctx;
        }

        public int Count()
        {
            return _ctx.Pets.Count();
        }

        public Pet Create(Pet pet)
        {
            _ctx.Attach(pet).State = EntityState.Added;
            _ctx.SaveChanges();
            return pet;
        }

        public Pet DeleteById(int id)
        {
            var pet = _ctx.Pets.FirstOrDefault(o => o.Id == id);
            var removed = _ctx.Remove(pet).Entity;
            _ctx.SaveChanges();
            return removed;
        }

        public FilteredList<Pet> ReadAll(Filter filter = null)
        {
            if (filter == null)
            {
                return new FilteredList<Pet>() { List = _ctx.Pets.ToList(), Count = _ctx.Pets.Count() };
            }

            var items = _ctx.Pets
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage)
                .ToList();
            return new FilteredList<Pet>() { List = items, Count = Count() };

        }

        public List<PetType> ReadPetTypes()
        {
            return _ctx.PetTypes.ToList();
        }

        public Pet ReadyById(int id)
        {
            return _ctx.Pets.Include(o => o.Owner)
                .FirstOrDefault(o => o.Id == id);
        }

        public Pet Update(Pet petUpdate)
        {
            _ctx.Attach(petUpdate);
            // Save it
            _ctx.SaveChanges();
            //Return it
            return petUpdate;
        }
    }
}
