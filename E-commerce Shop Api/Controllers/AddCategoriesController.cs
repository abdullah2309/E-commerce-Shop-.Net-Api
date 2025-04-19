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
    public class AddCategoriesController : ControllerBase
    {
        private readonly EcommerceShopContext _context;

        public AddCategoriesController(EcommerceShopContext context)
        {
            _context = context;
        }

        // GET: api/AddCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddCategory>>> GetAddCategories()
        {
            return await _context.AddCategories.ToListAsync();
        }

        // GET: api/AddCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddCategory>> GetAddCategory(int id)
        {
            var addCategory = await _context.AddCategories.FindAsync(id);

            if (addCategory == null)
            {
                return NotFound();
            }

            return addCategory;
        }

        // PUT: api/AddCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddCategory(int id, AddCategory addCategory)
        {
            if (id != addCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(addCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddCategoryExists(id))
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

        // POST: api/AddCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddCategory>> PostAddCategory(AddCategory addCategory)
        {
            _context.AddCategories.Add(addCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddCategory", new { id = addCategory.Id }, addCategory);
        }

        // DELETE: api/AddCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddCategory(int id)
        {
            var addCategory = await _context.AddCategories.FindAsync(id);
            if (addCategory == null)
            {
                return NotFound();
            }

            _context.AddCategories.Remove(addCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddCategoryExists(int id)
        {
            return _context.AddCategories.Any(e => e.Id == id);
        }
    }
}
