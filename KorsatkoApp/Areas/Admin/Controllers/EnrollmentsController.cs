using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KorsatkoApp.Areas.Admin.Models;
using KorsatkoApp.Data;

namespace KorsatkoApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Enrollments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enrollments.Include(e => e.session).Include(e => e.student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Enrollments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.session)
                .Include(e => e.student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Admin/Enrollments/Create
        public IActionResult Create()
        {
            ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Admin/Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentNumber,StudentId,SessionId,PaymentStatus,AddedOn")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Id", enrollment.SessionId);
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Admin/Enrollments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Id", enrollment.SessionId);
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id", enrollment.StudentId);
            return View(enrollment);
        }

        // POST: Admin/Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EnrollmentNumber,StudentId,SessionId,PaymentStatus,AddedOn")] Enrollment enrollment)
        {
            if (id != enrollment.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.StudentId))
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
            ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Id", enrollment.SessionId);
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Admin/Enrollments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.session)
                .Include(e => e.student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Admin/Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Enrollments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Enrollments'  is null.");
            }
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(string id)
        {
          return (_context.Enrollments?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
