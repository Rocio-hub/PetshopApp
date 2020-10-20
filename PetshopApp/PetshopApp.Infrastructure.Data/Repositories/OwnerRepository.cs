using PetshopApp.Core.DomainService;
using PetshopApp.Core.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetshopApp.Core.DomainService.Filtering;

namespace PetshopApp.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        readonly PetshopAppContext _ctx;

        public OwnerRepository(PetshopAppContext ctx)
        {
            _ctx = ctx;
        }

        public int Count()
        {
            return _ctx.Owners.Count();
        }

        public Owner CreateOwner(Owner owner)
        {
            var ownerSaved = _ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return ownerSaved;
        }

        public Owner DeleteOwnerById(int id)
        {
            var ownerRemoved = _ctx.Remove(new Owner { Id = id }).Entity;
            _ctx.SaveChanges();
            return ownerRemoved;
        }

        public FilteredList<Owner> ReadAll(Filter filter)
        {
            //Create a Filtered List
            var filteredList = new FilteredList<Owner>();

            //If there is a Filter then filter the list and set Count
            if (filter != null && filter.ItemsPrPage > 0 && filter.CurrentPage > 0)
            {
                filteredList.List = _ctx.Owners
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
                filteredList.Count = _ctx.Owners.Count();
                return filteredList;
            }

            //Else just return the full list and get the count from the list (to save a SQL call)
            filteredList.List = _ctx.Owners;
            filteredList.Count = filteredList.List.Count();
            return filteredList;
        }

        public Owner ReadyById(int id)
        {
            return _ctx.Owners
                 .FirstOrDefault(c => c.Id == id);
        }

        public Owner ReadyByIdIncludePets(int id)
        {
            return _ctx.Customers
                 .Include(c => c.Pets)
                 .FirstOrDefault(c => c.Id == id);
        }

        public Owner Update(Owner ownerUpdate)
        {
            _ctx.Attach(ownerUpdate).State = EntityState.Modified;
            _ctx.Entry(ownerUpdate).Collection(c => c.Pets).IsModified = true;
            var pets = _ctx.Pets.Where(o => o.Owner.Id == ownerUpdate.Id
                                   && !ownerUpdate.Pets.Exists(co => co.Id == o.Id));
            foreach (var pet in pets)
            {
                pet.Owner= null;
                _ctx.Entry(pet).Reference(o => o.Owner)
                    .IsModified = true;
            }
            _ctx.SaveChanges();
            return ownerUpdate;
        }
    }
}
