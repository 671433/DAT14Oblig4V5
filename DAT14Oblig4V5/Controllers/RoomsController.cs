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
    public class RoomsController : Controller
    {
        private readonly Oblig4Dat154DbContext _context;

        public RoomsController(Oblig4Dat154DbContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var oblig4Dat154DbContext = _context.Rooms.Include(r => r.BedOptionNavigation).Include(r => r.Hotel).Include(r => r.QualityNavigation);
            return View(await oblig4Dat154DbContext.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.BedOptionNavigation)
                .Include(r => r.Hotel)
                .Include(r => r.QualityNavigation)
                .FirstOrDefaultAsync(m => m.RoomNr == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["BedOption"] = new SelectList(_context.BedOptions, "BedOptionsId", "BedOptionsId");
            ViewData["HotelId"] = new SelectList(_context.Hotels, "HotelId", "HotelId");
            ViewData["Quality"] = new SelectList(_context.Qualities, "QualityId", "QualityId");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomNr,BedOption,RoomSize,Quality,HotelId")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BedOption"] = new SelectList(_context.BedOptions, "BedOptionsId", "BedOptionsId", room.BedOption);
            ViewData["HotelId"] = new SelectList(_context.Hotels, "HotelId", "HotelId", room.HotelId);
            ViewData["Quality"] = new SelectList(_context.Qualities, "QualityId", "QualityId", room.Quality);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["BedOption"] = new SelectList(_context.BedOptions, "BedOptionsId", "BedOptionsId", room.BedOption);
            ViewData["HotelId"] = new SelectList(_context.Hotels, "HotelId", "HotelId", room.HotelId);
            ViewData["Quality"] = new SelectList(_context.Qualities, "QualityId", "QualityId", room.Quality);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomNr,BedOption,RoomSize,Quality,HotelId")] Room room)
        {
            if (id != room.RoomNr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomNr))
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
            ViewData["BedOption"] = new SelectList(_context.BedOptions, "BedOptionsId", "BedOptionsId", room.BedOption);
            ViewData["HotelId"] = new SelectList(_context.Hotels, "HotelId", "HotelId", room.HotelId);
            ViewData["Quality"] = new SelectList(_context.Qualities, "QualityId", "QualityId", room.Quality);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.BedOptionNavigation)
                .Include(r => r.Hotel)
                .Include(r => r.QualityNavigation)
                .FirstOrDefaultAsync(m => m.RoomNr == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.RoomNr == id);
        }
    }
}
