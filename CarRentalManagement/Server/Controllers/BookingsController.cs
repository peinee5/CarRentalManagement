﻿using System;
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
    public class BookingsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored

        //public BookingsController(ApplicationDbContext context)
        public BookingsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Bookings
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        public async Task<IActionResult> GetBookings()
        {
          //if (_context.Bookings == null)
          //{
              //return NotFound();
          //}
            //Refactored
            //return await _context.Bookings.ToListAsync();
            var Bookings = await _unitOfWork.Bookings.GetAll();
            return Ok(Bookings);
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Booking>> GetBooking(int id)
        public async Task<IActionResult> GetBooking(int id)
        {
          //if (_context.Bookings == null)
          //{
              //return NotFound();
          //}
            //Refactores
            //var Booking = await _context.Bookings.FindAsync(id);
            var Booking = await _unitOfWork.Bookings.Get(q => q.Id == id);

            if (Booking == null)
            {
                return NotFound();
            }

            //Refactored
            //return Booking;
            return Ok(Booking);
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking Booking)
        {
            if (id != Booking.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(Booking).State = EntityState.Modified;
            _unitOfWork.Bookings.Update(Booking);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!BookingExists(id))
                if (!await BookingExists(id))
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

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking Booking)
        {
          //if (_context.Bookings == null)
          //{
              //return Problem("Entity set 'ApplicationDbContext.Bookings'  is null.");
          //}
            //Refactored
            //_context.Bookings.Add(Booking);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Bookings.Insert(Booking);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetBooking", new { id = Booking.Id }, Booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            //Refactored
            //if (_context.Bookings == null)
            //{
            //return NotFound();
            //}
            //var Booking = await _context.Bookings.FindAsync(id);
            var Booking = await _unitOfWork.Bookings.Get(q => q.Id == id);
            if (Booking == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Bookings.Remove(Booking);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Bookings.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool BookingExists(int id)
        private async Task<bool> BookingExists(int id)
        {
            //Refactored
            //return (_context.Bookings?.Any(e => e.Id == id)).GetValueOrDefault();
            var Booking = await _unitOfWork.Bookings.Get(q => q.Id == id);
            return Booking != null;
        }
    }
}
