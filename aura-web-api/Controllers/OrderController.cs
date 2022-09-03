using aura_web_api.Data;
using aura_web_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aura_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderDbContext _context;
        public OrderController(OrderDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Order>> Get() =>  await _context.Orders.ToListAsync();

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return order == null ? NotFound() : Ok(order);
        }

        //Single order
        //[HttpPost]
        //public async Task<IActionResult> Create(Order order)
        //{
        //    await _context.Orders.AddAsync(order);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateList(List<Order> orders)
        {
            foreach(var x in orders)
            {
                await _context.Orders.AddAsync(x);
            }
            int changed = await _context.SaveChangesAsync();

            return changed==0 ? NotFound() : Ok(orders);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Order order)
        {
            if (id != order.Id) return BadRequest();

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
