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
    public class ChapitresController : ControllerBase
    {
        private readonly ElearningContext _context;

        public ChapitresController(ElearningContext context)
        {
            _context = context;
        }

        // GET: api/Chapitres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chapitre>>> GetChapitre()
        {
            return await _context.Chapitre.Include(x => x.Lesson).ToListAsync();
        }

        // GET: api/Chapitres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chapitre>> GetChapitre(int id)
        {
            var chapitre = await _context.Chapitre.Include(x => x.Lesson).
                                                   ThenInclude(x => x.Video).
                                                   Include(x => x.Lesson).
                                                   ThenInclude(x => x.Document).
                                                   SingleAsync(x => x.Id == id);
            if (chapitre == null)
            {
                return NotFound();
            }

            return chapitre;
        }

        // PUT: api/Chapitres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChapitre(int id, Chapitre chapitre)
        {
            if (id != chapitre.Id)
            {
                return BadRequest();
            }

            _context.Entry(chapitre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChapitreExists(id))
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

        // POST: api/Chapitres
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Chapitre>> PostChapitre(Chapitre chapitre)
        {

            var id = 0;
            if (_context.Chapitre.Count() <= 0)
            {
                id = 0;

            }
            else
            {
                id = _context.Chapitre.Max(e => e.Id);

            }

            chapitre.Id = id + 1;
            _context.Chapitre.Add(chapitre);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChapitreExists(chapitre.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChapitre", new { id = chapitre.Id }, chapitre);
        }

        // DELETE: api/Chapitres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chapitre>> DeleteChapitre(int id)
        {
            var chapitre = await _context.Chapitre.FindAsync(id);
            if (chapitre == null)
            {
                return NotFound();
            }

            _context.Chapitre.Remove(chapitre);
            await _context.SaveChangesAsync();

            return chapitre;
        }

        private bool ChapitreExists(int id)
        {
            return _context.Chapitre.Any(e => e.Id == id);
        }
    }
}
