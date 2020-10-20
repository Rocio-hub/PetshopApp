using System.Collections.Generic;

namespace PetshopApp.Core.DomainService.Filtering
{
    public class FilteredList<T>
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}
