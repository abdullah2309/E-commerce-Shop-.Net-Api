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
    public class AddProductsController : ControllerBase
    {
        private readonly EcommerceShopContext _context;

        public AddProductsController(EcommerceShopContext context)
        {
            _context = context;
        }

        // GET: api/AddProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddProduct>>> GetAddProducts()
        {
            return await _context.AddProducts.ToListAsync();
        }

        // GET: api/AddProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddProduct>> GetAddProduct(int id)
        {
            var addProduct = await _context.AddProducts.FindAsync(id);

            if (addProduct == null)
            {
                return NotFound();
            }

            return addProduct;
        }

        // PUT: api/AddProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddProduct(int id, AddProduct addProduct)
        {
            if (id != addProduct.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(addProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddProductExists(id))
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

        // POST: api/AddProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddProduct>> PostAddProduct(AddProduct addProduct)
        {
            _context.AddProducts.Add(addProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddProduct", new { id = addProduct.ProductId }, addProduct);
        }

        // DELETE: api/AddProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddProduct(int id)
        {
            var addProduct = await _context.AddProducts.FindAsync(id);
            if (addProduct == null)
            {
                return NotFound();
            }

            _context.AddProducts.Remove(addProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddProductExists(int id)
        {
            return _context.AddProducts.Any(e => e.ProductId == id);
        }
    }
}
