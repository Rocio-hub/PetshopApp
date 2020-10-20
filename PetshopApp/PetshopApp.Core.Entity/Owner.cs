using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopApp.Core.Entity
{
    public class Owner
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Pet> Pets { get; set; }
    }
}
