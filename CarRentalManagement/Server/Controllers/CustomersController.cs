using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Server.Data;
using CarRentalManagement.Shared.Domain;
using CarRentalManagement.Server.IRepository;

namespace CarRentalManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored

        //public CustomersController(ApplicationDbContext context)
        public CustomersController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Customers
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        public async Task<IActionResult> GetCustomers()
        {
          //if (_context.Customers == null)
          //{
              //return NotFound();
          //}
            //Refactored
            //return await _context.Customers.ToListAsync();
            var Customers = await _unitOfWork.Customers.GetAll();
            return Ok(Customers);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Customer>> GetCustomer(int id)
        public async Task<IActionResult> GetCustomer(int id)
        {
          //if (_context.Customers == null)
          //{
              //return NotFound();
          //}
            //Refactores
            //var Customer = await _context.Customers.FindAsync(id);
            var Customer = await _unitOfWork.Customers.Get(q => q.Id == id);

            if (Customer == null)
            {
                return NotFound();
            }

            //Refactored
            //return Customer;
            return Ok(Customer);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer Customer)
        {
            if (id != Customer.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(Customer).State = EntityState.Modified;
            _unitOfWork.Customers.Update(Customer);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!CustomerExists(id))
                if (!await CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer Customer)
        {
          //if (_context.Customers == null)
          //{
              //return Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
          //}
            //Refactored
            //_context.Customers.Add(Customer);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Customers.Insert(Customer);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCustomer", new { id = Customer.Id }, Customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            //Refactored
            //if (_context.Customers == null)
            //{
            //return NotFound();
            //}
            //var Customer = await _context.Customers.FindAsync(id);
            var Customer = await _unitOfWork.Customers.Get(q => q.Id == id);
            if (Customer == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Customers.Remove(Customer);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Customers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool CustomerExists(int id)
        private async Task<bool> CustomerExists(int id)
        {
            //Refactored
            //return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
            var Customer = await _unitOfWork.Customers.Get(q => q.Id == id);
            return Customer != null;
        }
    }
}
