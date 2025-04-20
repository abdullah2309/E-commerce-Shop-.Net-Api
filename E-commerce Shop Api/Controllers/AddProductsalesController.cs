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
    public class AddProductsalesController : ControllerBase
    {
        private readonly EcommerceShopContext _context;

        public AddProductsalesController(EcommerceShopContext context)
        {
            _context = context;
        }

        // GET: api/AddProductsales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddProductsale>>> GetAddProductsales()
        {
            return await _context.AddProductsales.ToListAsync();
        }

        // GET: api/AddProductsales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddProductsale>> GetAddProductsale(int id)
        {
            var addProductsale = await _context.AddProductsales.FindAsync(id);

            if (addProductsale == null)
            {
                return NotFound();
            }

            return addProductsale;
        }

        // PUT: api/AddProductsales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddProductsale(int id, AddProductsale addProductsale)
        {
            if (id != addProductsale.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(addProductsale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddProductsaleExists(id))
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

        // POST: api/AddProductsales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddProductsale>> PostAddProductsale(AddProductsale addProductsale)
        {
            _context.AddProductsales.Add(addProductsale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddProductsale", new { id = addProductsale.ProductId }, addProductsale);
        }

        // DELETE: api/AddProductsales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddProductsale(int id)
        {
            var addProductsale = await _context.AddProductsales.FindAsync(id);
            if (addProductsale == null)
            {
                return NotFound();
            }

            _context.AddProductsales.Remove(addProductsale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddProductsaleExists(int id)
        {
            return _context.AddProductsales.Any(e => e.ProductId == id);
        }
    }
}
