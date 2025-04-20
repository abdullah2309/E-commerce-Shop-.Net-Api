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
    public class AdminloginsController : ControllerBase
    {
        private readonly EcommerceShopContext _context;

        public AdminloginsController(EcommerceShopContext context)
        {
            _context = context;
        }

        // GET: api/Adminlogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adminlogin>>> GetAdminlogins()
        {
            return await _context.Adminlogins.ToListAsync();
        }

        // GET: api/Adminlogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adminlogin>> GetAdminlogin(int id)
        {
            var adminlogin = await _context.Adminlogins.FindAsync(id);

            if (adminlogin == null)
            {
                return NotFound();
            }

            return adminlogin;
        }

        // PUT: api/Adminlogins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminlogin(int id, Adminlogin adminlogin)
        {
            if (id != adminlogin.Id)
            {
                return BadRequest();
            }

            _context.Entry(adminlogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminloginExists(id))
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

        // POST: api/Adminlogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adminlogin>> PostAdminlogin(Adminlogin adminlogin)
        {
            _context.Adminlogins.Add(adminlogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminlogin", new { id = adminlogin.Id }, adminlogin);
        }

        // DELETE: api/Adminlogins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminlogin(int id)
        {
            var adminlogin = await _context.Adminlogins.FindAsync(id);
            if (adminlogin == null)
            {
                return NotFound();
            }

            _context.Adminlogins.Remove(adminlogin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminloginExists(int id)
        {
            return _context.Adminlogins.Any(e => e.Id == id);
        }
    }
}
