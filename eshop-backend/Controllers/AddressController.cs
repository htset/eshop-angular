using eshop_backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eshop_backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("angular_eshop_AllowSpecificOrigins")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly EshopContext _context;

        public AddressController(EshopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> Get()
        {
            return await _context.Addresses.ToListAsync();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Address>>> GetByUserId(int userId)
        {
            return await _context.Addresses.Where((addr) => addr.UserId == userId).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Address>> Post([FromBody] Address value)
        {
            if (value.Id == 0)
            {
                await _context.Addresses.AddAsync(value);
            }
            else
            {
                _context.Addresses.Update(value);
            }
            await _context.SaveChangesAsync();
            return value;
        }

        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            var addr = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(addr);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
