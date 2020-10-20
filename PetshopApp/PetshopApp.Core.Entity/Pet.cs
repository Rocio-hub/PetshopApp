using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopApp.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public Type PetType { get; set; }
        public Owner Owner { get; set; }
        public string Color { get; set; }
    }
}
