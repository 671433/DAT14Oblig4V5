using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAT14Oblig4V5.Models;

namespace DAT14Oblig4V5.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly Oblig4Dat154DbContext _context;

        public ReservationsController(Oblig4Dat154DbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var oblig4Dat154DbContext = _context.Reservations.Include(r => r.Customer).Include(r => r.Hotel);
            return View(await oblig4Dat154DbContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.People, "PersonId", "PersonId");
            ViewData["HotelId"] = new SelectList(_context.Hotels, "HotelId", "HotelId");
            ViewData["RoomNr"] = new SelectList(_context.Rooms, "RoomNr", "RoomNr");
            return View();
        }


        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,CustomerId,HotelId,ReservationStart,ReservationEnd,Checkin,Checkout")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.People, "PersonId", "PersonId", reservation.CustomerId);
            
            ViewData["HotelId"] = new SelectList(_context.Hotels, "HotelId", "HotelId", reservation.HotelId);
            ViewData["RoomNr"] = new SelectList(_context.Rooms, "RoomNr", "RoomNr", reservation.RoomNr);




                return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.People, "PersonId", "PersonId", reservation.CustomerId);
            ViewData["HotelId"] = new SelectList(_context.Hotels, "HotelId", "HotelId", reservation.HotelId);
            ViewData["RoomNr"] = new SelectList(_context.Rooms, "RoomNr", "RoomNr", reservation.RoomNr);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,CustomerId,HotelId,ReservationStart,ReservationEnd,Checkin,Checkout")] Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.People, "PersonId", "PersonId", reservation.CustomerId);
            ViewData["HotelId"] = new SelectList(_context.Hotels, "HotelId", "HotelId", reservation.HotelId);
            ViewData["RoomNr"] = new SelectList(_context.Rooms, "RoomNr", "RoomNr", reservation.RoomNr);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationId == id);
        }
    }
}
