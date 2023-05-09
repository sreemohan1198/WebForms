using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;

namespace WebApplication6.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerLoginsController : ControllerBase
    {
        private readonly CustomerDbContext _context;

        public CustomerLoginsController(CustomerDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerLogin>>> GetCustomerLogin()
        {
          if (_context.CustomerLogin == null)
          {
              return NotFound();
          }
            return await _context.CustomerLogin.ToListAsync();
        }

        // GET: api/CustomerLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerLogin>> GetCustomerLogin(int id)
        {
          if (_context.CustomerLogin == null)
          {
              return NotFound();
          }
            var customerLogin = await _context.CustomerLogin.FindAsync(id);

            if (customerLogin == null)
            {
                return NotFound();
            }

            return customerLogin;
        }

        // PUT: api/CustomerLogins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerLogin(int id, CustomerLogin customerLogin)
        {
            if (id != customerLogin.LoginId)
            {
                return BadRequest();
            }

            _context.Entry(customerLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerLoginExists(id))
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

        // POST: api/CustomerLogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerLogin>> PostCustomerLogin(CustomerLogin customerLogin)
        {
          if (_context.CustomerLogin == null)
          {
              return Problem("Entity set 'CustomerDbContext.CustomerLogin'  is null.");
          }
            _context.CustomerLogin.Add(customerLogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerLogin", new { id = customerLogin.LoginId }, customerLogin);
        }

        // DELETE: api/CustomerLogins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerLogin(int id)
        {
            if (_context.CustomerLogin == null)
            {
                return NotFound();
            }
            var customerLogin = await _context.CustomerLogin.FindAsync(id);
            if (customerLogin == null)
            {
                return NotFound();
            }

            _context.CustomerLogin.Remove(customerLogin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerLoginExists(int id)
        {
            return (_context.CustomerLogin?.Any(e => e.LoginId == id)).GetValueOrDefault();
        }
    }
}
