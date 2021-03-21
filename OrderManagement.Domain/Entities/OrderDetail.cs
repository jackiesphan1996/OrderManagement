using OrderManagement.Domain.Common;

namespace OrderManagement.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
