using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventSpotterWeb.Data;
using EventSpotterWeb.Models;
using System.Net.Sockets;

namespace EventSpotterWeb.Controllers
{
    public class EventsController : Controller
    {
        private readonly DatabaseEventSpotter _context;

        public EventsController(DatabaseEventSpotter context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public async Task<IActionResult> Create()
        {
            // Vul de ViewBag met Categories en Organizers voor de dropdowns
            ViewData["CategoryID"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryID", "CategoryName");
            ViewData["OrganizerID"] = new SelectList(await _context.Organizers.ToListAsync(), "OrganizerID", "Name");
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,Name,Location,Date,MaxParticipants,Cost,AvailableSeats,Description,Image,CategoryID,OrganizerID")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Vul de dropdowns opnieuw in als er een fout is
            ViewData["CategoryID"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryID", "CategoryName", @event.CategoryID);
            ViewData["OrganizerID"] = new SelectList(await _context.Organizers.ToListAsync(), "OrganizerID", "Name", @event.OrganizerID);
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            // Vul de ViewBag met Categories en Organizers voor de dropdowns
            ViewData["CategoryID"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryID", "CategoryName", @event.CategoryID);
            ViewData["OrganizerID"] = new SelectList(await _context.Organizers.ToListAsync(), "OrganizerID", "Name", @event.OrganizerID);
            return View(@event);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,Name,Location,Date,MaxParticipants,Cost,AvailableSeats,Description,Image,CategoryID,OrganizerID")] Event @event)
        {
            if (id != @event.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventID))
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

            // Vul de dropdowns opnieuw in als er een fout is
            ViewData["CategoryID"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryID", "CategoryName", @event.CategoryID);
            ViewData["OrganizerID"] = new SelectList(await _context.Organizers.ToListAsync(), "OrganizerID", "Name", @event.OrganizerID);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event != null)
            {
                _context.Events.Remove(@event);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventID == id);
        }

        // New Action for Upcoming Events
        // GET: Events/UpcomingEvents
        public async Task<IActionResult> UpcomingEvents()
        {
            var today = DateTime.Now;

            // Fetch events that are in the future
            var upcomingEvents = await _context.Events
                .Where(e => e.Date >= today)
                .OrderBy(e => e.Date) // Order by date
                .ToListAsync();

            return View(upcomingEvents);
        }

        // New Reserve Action
        // GET: Events/Reserve
        public async Task<IActionResult> Reserve(int eventId, int participantId, int numTickets)
        {
            var eventToReserve = await _context.Events.FindAsync(eventId);
            if (eventToReserve == null || eventToReserve.AvailableSeats < numTickets)
            {
                // Niet genoeg beschikbare plaatsen
                return NotFound();
            }

            // Maak een nieuwe reservering aan
            var reservation = new Reservation
            {
                EventID = eventId,
                ParticipantID = participantId,
                ReservationDate = DateTime.Now,
                NumTickets = numTickets,
                TotalPrice = eventToReserve.Cost * numTickets,
                PaymentStatus = "Pending",
                ConfirmationOrder = Guid.NewGuid().ToString() // Genereer een unieke identificatie
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            // Maak tickets aan voor elke gereserveerde plaats
            for (int i = 0; i < numTickets; i++)
            {
                var ticket = new Tickets
                {
                    ReservationID = reservation.ReservationID,
                    SeatNumber = $"Seat-{i + 1}"
                };
                _context.Tickets.Add(ticket);
            }

            // Verminder het aantal beschikbare plaatsen
            eventToReserve.AvailableSeats -= numTickets;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = eventId });
        }
    }
}
