using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventSpotterWeb.Data;
using EventSpotterWeb.Models;

namespace EventSpotterWeb.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly DatabaseEventSpotter _context;

        public ReservationsController(DatabaseEventSpotter context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var databaseEventSpotter = _context.Reservations.Include(r => r.Event).Include(r => r.Participant).Include(r => r.Payment);
            return View(await databaseEventSpotter.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Event)
                .Include(r => r.Participant)
                .Include(r => r.Payment)
                .FirstOrDefaultAsync(m => m.ReservationID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "Name");
            ViewData["ParticipantID"] = new SelectList(_context.Participants, "ParticipantID", "Name");
            ViewData["PaymentID"] = new SelectList(_context.Payments, "PaymentID", "PaymentID");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationID,ReservationDate,NumTickets,TotalPrice,PaymentStatus,ConfirmationOrder,EventID,ParticipantID,PaymentID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "Name", reservation.EventID);
            ViewData["ParticipantID"] = new SelectList(_context.Participants, "ParticipantID", "Name", reservation.ParticipantID);
            ViewData["PaymentID"] = new SelectList(_context.Payments, "PaymentID", "PaymentID", reservation.PaymentID);
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
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "Name", reservation.EventID);
            ViewData["ParticipantID"] = new SelectList(_context.Participants, "ParticipantID", "Name", reservation.ParticipantID);
            ViewData["PaymentID"] = new SelectList(_context.Payments, "PaymentID", "PaymentID", reservation.PaymentID);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationID,ReservationDate,NumTickets,TotalPrice,PaymentStatus,ConfirmationOrder,EventID,ParticipantID,PaymentID")] Reservation reservation)
        {
            if (id != reservation.ReservationID)
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
                    if (!ReservationExists(reservation.ReservationID))
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
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "Name", reservation.EventID);
            ViewData["ParticipantID"] = new SelectList(_context.Participants, "ParticipantID", "Name", reservation.ParticipantID);
            ViewData["PaymentID"] = new SelectList(_context.Payments, "PaymentID", "PaymentID", reservation.PaymentID);
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
                .Include(r => r.Event)
                .Include(r => r.Participant)
                .Include(r => r.Payment)
                .FirstOrDefaultAsync(m => m.ReservationID == id);
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
            return _context.Reservations.Any(e => e.ReservationID == id);
        }
    }
}
