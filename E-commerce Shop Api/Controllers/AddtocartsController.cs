using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_commerce_Shop_Api.Models;

namespace E_commerce_Shop_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddtocartsController : ControllerBase
    {
        private readonly EcommerceShopContext _context;

        public AddtocartsController(EcommerceShopContext context)
        {
            _context = context;
        }

        // GET: api/Addtocarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Addtocart>>> GetAddtocarts()
        {
            return await _context.Addtocarts.ToListAsync();
        }

        // GET: api/Addtocarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Addtocart>> GetAddtocart(int id)
        {
            var addtocart = await _context.Addtocarts.FindAsync(id);

            if (addtocart == null)
            {
                return NotFound();
            }

            return addtocart;
        }

        // PUT: api/Addtocarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddtocart(int id, Addtocart addtocart)
        {
            if (id != addtocart.Id)
            {
                return BadRequest();
            }

            _context.Entry(addtocart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddtocartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Addtocarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Addtocart>> PostAddtocart(Addtocart addtocart)
        {
            _context.Addtocarts.Add(addtocart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddtocart", new { id = addtocart.Id }, addtocart);
        }

        // DELETE: api/Addtocarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddtocart(int id)
        {
            var addtocart = await _context.Addtocarts.FindAsync(id);
            if (addtocart == null)
            {
                return NotFound();
            }

            _context.Addtocarts.Remove(addtocart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddtocartExists(int id)
        {
            return _context.Addtocarts.Any(e => e.Id == id);
        }
    }
}
