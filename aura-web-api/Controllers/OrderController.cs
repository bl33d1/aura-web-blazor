using aura_web_api.Data;
using aura_web_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace aura_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderDbContext _context;
        public OrderController(OrderDbContext context) => _context = context;

        SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        [HttpGet]
        public async Task<IEnumerable<Order>> Get() => await _context.Orders.ToListAsync();

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

        //[HttpPost("{company}")]
        //public async Task<IActionResult> CreateList(string company, List<Order> orders)
        //{
        //    foreach (var x in orders)
        //    {
        //        await _context.Orders.AddAsync(x);
        //    }
        //    int changed = await _context.SaveChangesAsync();

        //    return changed == 0 ? NotFound() : Ok(company);
        //}
        [HttpPost("{company}")]
        public IActionResult CreateList(string company, List<Order> orders)
        {
            int changes = 0;
            conn.Open();
            if(orders != null)
            {
                foreach (var x in orders)
                {
                    SqlCommand cmd = new SqlCommand("AddOrders", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Mytable", company);
                    cmd.Parameters.AddWithValue("@Artikulli1", x.Artikulli);
                    cmd.Parameters.AddWithValue("@Sasia", x.Sasia);
                    cmd.Parameters.AddWithValue("@Nj2", x.Nj2);
                    cmd.Parameters.AddWithValue("@Qmimi", x.Qmimi);
                    cmd.Parameters.AddWithValue("@Kamarieri", x.Kamarieri);
                    cmd.Parameters.AddWithValue("@Ora", x.Ora);
                    cmd.Parameters.AddWithValue("@Data", x.Data);
                    cmd.Parameters.AddWithValue("@Tavolina", x.Tavolina);
                    cmd.Parameters.AddWithValue("@Vlera", x.Vlera);
                    cmd.Parameters.AddWithValue("@NrPorosise", x.NrPorosise);
                    cmd.Parameters.AddWithValue("@EshteMbyllur", x.EshteMbyllur);
                    changes = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                conn.Close();
                //(Artikulli,Sasia,Nj2,Qmimi,Kamarieri,Ora,Data,Tavolina,Vlera,NrPorosise,EshteMbyllur)
                
            }
            return changes > 0 ? this.StatusCode(StatusCodes.Status201Created,company + ":"+ changes) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Order order)
        {
            if (id != order.Id) return BadRequest();

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {

            _context.Remove(_context);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
