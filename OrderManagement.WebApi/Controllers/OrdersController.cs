using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Contexts;

namespace OrderManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderViewModel>> GetOrder(int id)
        {
            var order = await _context.Orders.Include(x => x.OrderDetails)
                .ThenInclude(x => x.Item)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            var result = new OrderViewModel
            {
                Id = order.Id,
                Status = order.Status,
                TotalValue = order.TotalValue,
                UserId = order.UserId,
                OrderDetails = order.OrderDetails.Select(x => new OrderDetailViewModel
                {
                    Id = x.Id,
                    ItemId = x.ItemId,
                    ItemName = x.Item.Name,
                    Quantity = x.Quantity,
                    Price = x.Price
                }).ToList()
            };

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Order>> PostOrder(int id, [FromBody] OrderStatusChangeRequest status)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(x => x.Id == id);

            order.Status = status.Status;

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }
    }

    public class OrderViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set;}
        public decimal TotalValue { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<OrderDetailViewModel> OrderDetails { get; set; }
    }

    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderStatusChangeRequest
    {
        public Status Status { get; set; }
    }
}
