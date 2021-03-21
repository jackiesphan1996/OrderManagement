using System.Collections.Generic;
using OrderManagement.Domain.Common;

namespace OrderManagement.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
