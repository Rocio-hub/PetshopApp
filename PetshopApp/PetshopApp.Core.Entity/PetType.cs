using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopApp.Core.Entity
{
    public class PetType
    {
        public int Id { get; set; }

        public string TypeName { get; set; }

        public static implicit operator Type(PetType v)
        {
            throw new NotImplementedException();
        }
    }
}
