using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspCore_Angular_SqlServer.Models;

namespace AspCore_Angular_SqlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonElevesController : ControllerBase
    {
        private readonly ElearningContext _context;

        public LessonElevesController(ElearningContext context)
        {
            _context = context;
        }

        // GET: api/LessonEleves1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonEleve>>> GetLessonEleve()
        {
            return await _context.LessonEleve.ToListAsync();
        }

        // GET: api/LessonEleves1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonEleve>> GetLessonEleve(int id)
        {
            var lessonEleve = await _context.LessonEleve.FindAsync(id);

            if (lessonEleve == null)
            {
                return NotFound();
            }

            return lessonEleve;
        }

        // PUT: api/LessonEleves1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLessonEleve(int id, LessonEleve lessonEleve)
        {
            if (id != lessonEleve.Id)
            {
                return BadRequest();
            }

            _context.Entry(lessonEleve).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonEleveExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LessonEleves1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LessonEleve>> PostLessonEleve(LessonEleve lessonEleve)
        {
            var id = 0;
            if (_context.LessonEleve.Count() <= 0)
            {
                id = 0;

            }
            else
            {
                id = _context.LessonEleve.Max(e => e.Id);

            }

            lessonEleve.Id = id + 1;
            _context.LessonEleve.Add(lessonEleve);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LessonEleveExists(lessonEleve.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLessonEleve", new { id = lessonEleve.Id }, lessonEleve);
        }

        // DELETE: api/LessonEleves1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LessonEleve>> DeleteLessonEleve(int id)
        {
            var lessonEleve = await _context.LessonEleve.FindAsync(id);
            if (lessonEleve == null)
            {
                return NotFound();
            }

            _context.LessonEleve.Remove(lessonEleve);
            await _context.SaveChangesAsync();

            return lessonEleve;
        }

        private bool LessonEleveExists(int id)
        {
            return _context.LessonEleve.Any(e => e.Id == id);
        }
    }
}
