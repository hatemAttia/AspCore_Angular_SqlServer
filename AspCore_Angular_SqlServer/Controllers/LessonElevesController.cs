using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspCore_Angular_SqlServer.Models;

namespace AspCore_Angular_SqlServer.Controllers
{
    public class LessonElevesController : Controller
    {
        private readonly ElearningContext _context;

        public LessonElevesController(ElearningContext context)
        {
            _context = context;
        }

        // GET: LessonEleves
        public async Task<IActionResult> Index()
        {
            var elearningContext = _context.LessonEleve.Include(l => l.Eleve).Include(l => l.Lesson);
            return View(await elearningContext.ToListAsync());
        }

        // GET: LessonEleves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonEleve = await _context.LessonEleve
                .Include(l => l.Eleve)
                .Include(l => l.Lesson)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lessonEleve == null)
            {
                return NotFound();
            }

            return View(lessonEleve);
        }

        // GET: LessonEleves/Create
        public IActionResult Create()
        {
            ViewData["EleveId"] = new SelectList(_context.Eleve, "Id", "Id");
            ViewData["LessonId"] = new SelectList(_context.Lesson, "Id", "Id");
            return View();
        }

        // POST: LessonEleves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EleveId,LessonId")] LessonEleve lessonEleve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lessonEleve);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EleveId"] = new SelectList(_context.Eleve, "Id", "Id", lessonEleve.EleveId);
            ViewData["LessonId"] = new SelectList(_context.Lesson, "Id", "Id", lessonEleve.LessonId);
            return View(lessonEleve);
        }

        // GET: LessonEleves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonEleve = await _context.LessonEleve.FindAsync(id);
            if (lessonEleve == null)
            {
                return NotFound();
            }
            ViewData["EleveId"] = new SelectList(_context.Eleve, "Id", "Id", lessonEleve.EleveId);
            ViewData["LessonId"] = new SelectList(_context.Lesson, "Id", "Id", lessonEleve.LessonId);
            return View(lessonEleve);
        }

        // POST: LessonEleves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EleveId,LessonId")] LessonEleve lessonEleve)
        {
            if (id != lessonEleve.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lessonEleve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonEleveExists(lessonEleve.Id))
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
            ViewData["EleveId"] = new SelectList(_context.Eleve, "Id", "Id", lessonEleve.EleveId);
            ViewData["LessonId"] = new SelectList(_context.Lesson, "Id", "Id", lessonEleve.LessonId);
            return View(lessonEleve);
        }

        // GET: LessonEleves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonEleve = await _context.LessonEleve
                .Include(l => l.Eleve)
                .Include(l => l.Lesson)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lessonEleve == null)
            {
                return NotFound();
            }

            return View(lessonEleve);
        }

        // POST: LessonEleves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lessonEleve = await _context.LessonEleve.FindAsync(id);
            _context.LessonEleve.Remove(lessonEleve);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonEleveExists(int id)
        {
            return _context.LessonEleve.Any(e => e.Id == id);
        }
    }
}
