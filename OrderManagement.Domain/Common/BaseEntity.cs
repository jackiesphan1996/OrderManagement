using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Domain.Common
{
    public abstract class  BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
