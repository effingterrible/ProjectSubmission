using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectSubmission.Models;

namespace ProjectSubmission.Controllers
{
    public class SubmissionsControllerold : Controller
    {
        private readonly ProjectSubmissionContext _context;

        public SubmissionsControllerold(ProjectSubmissionContext context)
        {
            _context = context;
        }

        // GET: Submissions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Submissions.ToListAsync());
        }

        // GET: Submissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submissions = await _context.Submissions
                .SingleOrDefaultAsync(m => m.ID == id);
            if (submissions == null)
            {
                return NotFound();
            }

            return View(submissions);
        }

        // GET: Submissions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Submissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,submitter,submission,refTicket")] Submissions submissions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(submissions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(submissions);
        }

        // GET: Submissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submissions = await _context.Submissions.SingleOrDefaultAsync(m => m.ID == id);
            if (submissions == null)
            {
                return NotFound();
            }
            return View(submissions);
        }

        // POST: Submissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,submitter,submission,refTicket")] Submissions submissions)
        {
            if (id != submissions.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(submissions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubmissionsExists(submissions.ID))
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
            return View(submissions);
        }

        // GET: Submissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submissions = await _context.Submissions
                .SingleOrDefaultAsync(m => m.ID == id);
            if (submissions == null)
            {
                return NotFound();
            }

            return View(submissions);
        }

        // POST: Submissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var submissions = await _context.Submissions.SingleOrDefaultAsync(m => m.ID == id);
            _context.Submissions.Remove(submissions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubmissionsExists(int id)
        {
            return _context.Submissions.Any(e => e.ID == id);
        }
    }
}
