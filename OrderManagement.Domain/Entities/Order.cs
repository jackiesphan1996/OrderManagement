using System.Collections.Generic;
using OrderManagement.Domain.Common;

namespace OrderManagement.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Table { get; set; }
        public string UserId { get; set; }
        public decimal TotalValue { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

    public enum Status
    {
        Waiting,
        Cooking,
        Delivery,
        Complete
    }
}
