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
    public class DayViewsController : Controller
    {
        private readonly Oblig4Dat154DbContext _context;

        public DayViewsController(Oblig4Dat154DbContext context)
        {
            _context = context;
        }

        // GET: DayViews
        public async Task<IActionResult> Index()
        {
            var oblig4Dat154DbContext = _context.DayViews.Include(d => d.CleaningStatusNavigation).Include(d => d.MaintenanceStatusNavigation).Include(d => d.Reservation).Include(d => d.RoomNrNavigation).Include(d => d.RoomStatusNavigation).Include(d => d.ServiceStatusNavigation);
            return View(await oblig4Dat154DbContext.ToListAsync());
        }

        // GET: DayViews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayView = await _context.DayViews
                .Include(d => d.CleaningStatusNavigation)
                .Include(d => d.MaintenanceStatusNavigation)
                .Include(d => d.Reservation)
                .Include(d => d.RoomNrNavigation)
                .Include(d => d.RoomStatusNavigation)
                .Include(d => d.ServiceStatusNavigation)
                .FirstOrDefaultAsync(m => m.DayViewId == id);
            if (dayView == null)
            {
                return NotFound();
            }

            return View(dayView);
        }

        // GET: DayViews/Create
        public IActionResult Create()
        {
            ViewData["CleaningStatus"] = new SelectList(_context.RoomRequestEnums, "RoomRequestEnumId", "RoomRequestEnumId");
            ViewData["MaintenanceStatus"] = new SelectList(_context.RoomRequestEnums, "RoomRequestEnumId", "RoomRequestEnumId");
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "ReservationId", "ReservationId");
            ViewData["RoomNr"] = new SelectList(_context.Rooms, "RoomNr", "RoomNr");
            ViewData["RoomStatus"] = new SelectList(_context.RoomStatuses, "RoomStatusId", "RoomStatusId");
            ViewData["ServiceStatus"] = new SelectList(_context.RoomRequestEnums, "RoomRequestEnumId", "RoomRequestEnumId");
            return View();
        }

        // POST: DayViews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DayViewId,Date,ReservationId,RoomService,RoomStatus,CleaningStatus,ServiceStatus,MaintenanceStatus,RoomNr")] DayView dayView)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dayView);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CleaningStatus"] = new SelectList(_context.RoomRequestEnums, "RoomRequestEnumId", "RoomRequestEnumId", dayView.CleaningStatus);
            ViewData["MaintenanceStatus"] = new SelectList(_context.RoomRequestEnums, "RoomRequestEnumId", "RoomRequestEnumId", dayView.MaintenanceStatus);
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "ReservationId", "ReservationId", dayView.ReservationId);
            ViewData["RoomNr"] = new SelectList(_context.Rooms, "RoomNr", "RoomNr", dayView.RoomNr);
            ViewData["RoomStatus"] = new SelectList(_context.RoomStatuses, "RoomStatusId", "RoomStatusId", dayView.RoomStatus);
            ViewData["ServiceStatus"] = new SelectList(_context.RoomRequestEnums, "RoomRequestEnumId", "RoomRequestEnumId", dayView.ServiceStatus);
            return View(dayView);
        }

        // GET: DayViews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayView = await _context.DayViews.FindAsync(id);
            if (dayView == null)
            {
                return NotFound();
            }
            ViewData["CleaningStatus"] = new SelectList(_context.RoomRequestEnums, "RoomRequestEnumId", "RoomRequestEnumId", dayView.CleaningStatus);
            ViewData["MaintenanceStatus"] = new SelectList(_context.RoomRequestEnums, "RoomRequestEnumId", "RoomRequestEnumId", dayView.MaintenanceStatus);
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "ReservationId", "ReservationId", dayView.ReservationId);
            ViewData["RoomNr"] = new SelectList(_context.Rooms, "RoomNr", "RoomNr", dayView.RoomNr);
            ViewData["RoomStatus"] = new SelectList(_context.RoomStatuses, "RoomStatusId", "RoomStatusId", dayView.RoomStatus);
            ViewData["ServiceStatus"] = new SelectList(_context.RoomRequestEnums, "RoomRequestEnumId", "RoomRequestEnumId", dayView.ServiceStatus);
            return View(dayView);
        }

        // POST: DayViews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DayViewId,Date,ReservationId,RoomService,RoomStatus,CleaningStatus,ServiceStatus,MaintenanceStatus,RoomNr")] DayView dayView)
        {
            if (id != dayView.DayViewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dayView);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DayViewExists(dayView.DayViewId))
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
            ViewData["CleaningStatus"] = new SelectList(_context.RoomRequestEnums, "RoomRequestEnumId", "RoomRequestEnumId", dayView.CleaningStatus);
            ViewData["MaintenanceStatus"] = new SelectList(_context.RoomRequestEnums, "RoomRequestEnumId", "RoomRequestEnumId", dayView.MaintenanceStatus);
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "ReservationId", "ReservationId", dayView.ReservationId);
            ViewData["RoomNr"] = new SelectList(_context.Rooms, "RoomNr", "RoomNr", dayView.RoomNr);
            ViewData["RoomStatus"] = new SelectList(_context.RoomStatuses, "RoomStatusId", "RoomStatusId", dayView.RoomStatus);
            ViewData["ServiceStatus"] = new SelectList(_context.RoomRequestEnums, "RoomRequestEnumId", "RoomRequestEnumId", dayView.ServiceStatus);
            return View(dayView);
        }

        // GET: DayViews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayView = await _context.DayViews
                .Include(d => d.CleaningStatusNavigation)
                .Include(d => d.MaintenanceStatusNavigation)
                .Include(d => d.Reservation)
                .Include(d => d.RoomNrNavigation)
                .Include(d => d.RoomStatusNavigation)
                .Include(d => d.ServiceStatusNavigation)
                .FirstOrDefaultAsync(m => m.DayViewId == id);
            if (dayView == null)
            {
                return NotFound();
            }

            return View(dayView);
        }

        // POST: DayViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dayView = await _context.DayViews.FindAsync(id);
            if (dayView != null)
            {
                _context.DayViews.Remove(dayView);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DayViewExists(int id)
        {
            return _context.DayViews.Any(e => e.DayViewId == id);
        }
    }
}
