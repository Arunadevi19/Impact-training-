using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Leave;

namespace Leave.Controllers
{
    public class LeaveController : Controller
    {
        private readonly EFCoreWebDemoContext _context;

        public LeaveController(EFCoreWebDemoContext context)
        {
            _context = context;
        }

        // GET: Leave
        public async Task<IActionResult> Index()
        {
              return _context.Leavea != null ? 
                          View(await _context.Leavea.ToListAsync()) :
                          Problem("Entity set 'EFCoreWebDemoContext.Leavea'  is null.");
        }

        // GET: Leave/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Leavea == null)
            {
                return NotFound();
            }

            var leavea = await _context.Leavea
                .FirstOrDefaultAsync(m => m.LeaveId == id);
            if (leavea == null)
            {
                return NotFound();
            }

            return View(leavea);
        }

        // GET: Leave/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leave/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaveId,EmployeeId,StartDate,EndDate,LeaveType,Status")] Leavea leavea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leavea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leavea);
        }

        // GET: Leave/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Leavea == null)
            {
                return NotFound();
            }

            var leavea = await _context.Leavea.FindAsync(id);
            if (leavea == null)
            {
                return NotFound();
            }
            return View(leavea);
        }

        // POST: Leave/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaveId,EmployeeId,StartDate,EndDate,LeaveType,Status")] Leavea leavea)
        {
            if (id != leavea.LeaveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leavea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveaExists(leavea.LeaveId))
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
            return View(leavea);
        }

        // GET: Leave/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Leavea == null)
            {
                return NotFound();
            }

            var leavea = await _context.Leavea
                .FirstOrDefaultAsync(m => m.LeaveId == id);
            if (leavea == null)
            {
                return NotFound();
            }

            return View(leavea);
        }

        // POST: Leave/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Leavea == null)
            {
                return Problem("Entity set 'EFCoreWebDemoContext.Leavea'  is null.");
            }
            var leavea = await _context.Leavea.FindAsync(id);
            if (leavea != null)
            {
                _context.Leavea.Remove(leavea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveaExists(int id)
        {
          return (_context.Leavea?.Any(e => e.LeaveId == id)).GetValueOrDefault();
        }
    }
}
