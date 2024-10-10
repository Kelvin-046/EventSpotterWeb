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
    public class TicketManagementsController : Controller
    {
        private readonly DatabaseEventSpotter _context;

        public TicketManagementsController(DatabaseEventSpotter context)
        {
            _context = context;
        }

        // GET: TicketManagements
        public async Task<IActionResult> Index()
        {
            var databaseEventSpotter = _context.TicketManagements.Include(t => t.Ticket);
            return View(await databaseEventSpotter.ToListAsync());
        }

        // GET: TicketManagements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketManagement = await _context.TicketManagements
                .Include(t => t.Ticket)
                .FirstOrDefaultAsync(m => m.TicketManagementID == id);
            if (ticketManagement == null)
            {
                return NotFound();
            }

            return View(ticketManagement);
        }

        // GET: TicketManagements/Create
        public IActionResult Create()
        {
            ViewData["TicketID"] = new SelectList(_context.Tickets, "TicketID", "SeatNumber");
            return View();
        }

        // POST: TicketManagements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketManagementID,Status,TicketID")] TicketManagement ticketManagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicketID"] = new SelectList(_context.Tickets, "TicketID", "SeatNumber", ticketManagement.TicketID);
            return View(ticketManagement);
        }

        // GET: TicketManagements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketManagement = await _context.TicketManagements.FindAsync(id);
            if (ticketManagement == null)
            {
                return NotFound();
            }
            ViewData["TicketID"] = new SelectList(_context.Tickets, "TicketID", "SeatNumber", ticketManagement.TicketID);
            return View(ticketManagement);
        }

        // POST: TicketManagements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("TicketManagementID,Status,TicketID")] TicketManagement ticketManagement)
        {
            if (id != ticketManagement.TicketManagementID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketManagementExists(ticketManagement.TicketManagementID))
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
            ViewData["TicketID"] = new SelectList(_context.Tickets, "TicketID", "SeatNumber", ticketManagement.TicketID);
            return View(ticketManagement);
        }

        // GET: TicketManagements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketManagement = await _context.TicketManagements
                .Include(t => t.Ticket)
                .FirstOrDefaultAsync(m => m.TicketManagementID == id);
            if (ticketManagement == null)
            {
                return NotFound();
            }

            return View(ticketManagement);
        }

        // POST: TicketManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var ticketManagement = await _context.TicketManagements.FindAsync(id);
            if (ticketManagement != null)
            {
                _context.TicketManagements.Remove(ticketManagement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketManagementExists(int? id)
        {
            return _context.TicketManagements.Any(e => e.TicketManagementID == id);
        }
    }
}
