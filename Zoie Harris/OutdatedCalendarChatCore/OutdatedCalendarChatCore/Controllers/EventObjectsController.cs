using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutdatedCalendarChatCore.Models;

namespace EventAppPage.Controllers
{
    public class EventObjectsController : Controller
    {
        private readonly OutdatedCalendarContext _context;

        public EventObjectsController(OutdatedCalendarContext context)
        {
            _context = context;
        }

        // GET: EventObjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventObjects.ToListAsync());
        }

        // GET: EventObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventObject = await _context.EventObjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventObject == null)
            {
                return NotFound();
            }

            return View(eventObject);
        }

        // GET: EventObjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventObjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartTime,EndTime,Title,Description,Creator,Tags")] EventObject eventObject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventObject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventObject);
        }

        // GET: EventObjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventObject = await _context.EventObjects.FindAsync(id);
            if (eventObject == null)
            {
                return NotFound();
            }
            return View(eventObject);
        }

        // POST: EventObjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartTime,EndTime,Title,Description,Creator,Tags")] EventObject eventObject)
        {
            if (id != eventObject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventObject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventObjectExists(eventObject.Id))
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
            return View(eventObject);
        }

        // GET: EventObjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventObject = await _context.EventObjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventObject == null)
            {
                return NotFound();
            }

            return View(eventObject);
        }

        // POST: EventObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventObject = await _context.EventObjects.FindAsync(id);
            _context.EventObjects.Remove(eventObject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventObjectExists(int id)
        {
            return _context.EventObjects.Any(e => e.Id == id);
        }
    }
}
