using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CODE_DB.Models;
using NToastNotify;

namespace CODE_DB.Controllers
{

    public class IT_TraineeController : Controller
    {
        private readonly ILogger<IT_TraineeController> _logger;
        private readonly IToastNotification _toastNotification;
        private readonly T_Context _context;

        public IT_TraineeController(ILogger<IT_TraineeController> logger, IToastNotification toastNotification, T_Context context)
        {
            _logger = logger;
            _toastNotification = toastNotification;
            _context = context;
        }

        // GET: IT_Trainee
        public async Task<IActionResult> Index()
        {
              return View(await _context.IT_Trainees.ToListAsync());
        }

        // GET: IT_Trainee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IT_Trainees == null)
            {
                return NotFound();
            }

            var iT_Trainee = await _context.IT_Trainees
                .FirstOrDefaultAsync(m => m.TraineeID == id);
            if (iT_Trainee == null)
            {
                return NotFound();
            }

            return View(iT_Trainee);
        }

        // GET: IT_Trainee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IT_Trainee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TraineeID,TraineeName,TraineeAge,TraineeDOJ,TraineeDOB,TraineeMobile,TraineeEmail")] IT_Trainee iT_Trainee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iT_Trainee);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Trainee created successfully");
                return RedirectToAction(nameof(Index));
            }
            return View(iT_Trainee);
        }

        // GET: IT_Trainee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IT_Trainees == null)
            {
                return NotFound();
            }

            var iT_Trainee = await _context.IT_Trainees.FindAsync(id);
            if (iT_Trainee == null)
            {
                return NotFound();
            }
            return View(iT_Trainee);
        }

        // POST: IT_Trainee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TraineeID,TraineeName,TraineeAge,TraineeDOJ,TraineeDOB,TraineeMobile,TraineeEmail")] IT_Trainee iT_Trainee)
        {
            if (id != iT_Trainee.TraineeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iT_Trainee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IT_TraineeExists(iT_Trainee.TraineeID))
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
            return View(iT_Trainee);
        }

        // GET: IT_Trainee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IT_Trainees == null)
            {
                return NotFound();
            }

            var iT_Trainee = await _context.IT_Trainees
                .FirstOrDefaultAsync(m => m.TraineeID == id);
            if (iT_Trainee == null)
            {
                return NotFound();
            }

            return View(iT_Trainee);
        }

        // POST: IT_Trainee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IT_Trainees == null)
            {
                return Problem("Entity set 'T_Context.IT_Trainees'  is null.");
            }
            var iT_Trainee = await _context.IT_Trainees.FindAsync(id);
            if (iT_Trainee != null)
            {
                _context.IT_Trainees.Remove(iT_Trainee);
            }
            
            await _context.SaveChangesAsync();
            _toastNotification.AddErrorToastMessage("Trainee deleted successfully");
            return RedirectToAction(nameof(Index));
        }

        private bool IT_TraineeExists(int id)
        {
          return _context.IT_Trainees.Any(e => e.TraineeID == id);
        }
    }
}
