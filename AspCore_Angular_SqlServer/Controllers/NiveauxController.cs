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
    public class NiveauxController : ControllerBase
    {
        private readonly ElearningContext _context;

        public NiveauxController(ElearningContext context)
        {
            _context = context;
        }

        // GET: api/Niveaux
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Niveau>>> GetNiveau()
        {
            return await _context.Niveau.Include(x => x.Matiere)
                                          .ThenInclude(x => x.Chapitre)
                                          .ThenInclude(x => x.Lesson)
                                          .Include(x => x.Section)
                                          .ToListAsync();
        }

        // GET: api/Niveaux/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Niveau>> GetNiveau(int id)
        {
            var niveau = await _context.Niveau.Include(x => x.Section)
                                          .Include(x => x.Matiere)
                                          .ThenInclude(x => x.Chapitre  )
                                          .ThenInclude(x => x.Lesson)
                                          .ThenInclude(x => x.Document)
                                          .SingleAsync(x => x.Id == id);
            ;

            if (niveau == null)
            {
                return NotFound();
            }

            return niveau;
        }

        // PUT: api/Niveaux/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNiveau(int id, Niveau niveau)
        {
            if (id != niveau.Id)
            {
                return BadRequest();
            }

            _context.Entry(niveau).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NiveauExists(id))
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

        // POST: api/Niveaux
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Niveau>> PostNiveau(Niveau niveau)
        {
            var id = 0;
            if (_context.Niveau.Count() <= 0)
            {
                id = 0;

            }
            else
            {
                id = _context.Niveau.Max(e => e.Id);

            }
            niveau.Id = id + 1;
            _context.Niveau.Add(niveau);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NiveauExists(niveau.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNiveau", new { id = niveau.Id }, niveau);
        }

        // DELETE: api/Niveaux/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Niveau>> DeleteNiveau(int id)
        {
            var niveau = await _context.Niveau.FindAsync(id);
            if (niveau == null)
            {
                return NotFound();
            }

            _context.Niveau.Remove(niveau);
            await _context.SaveChangesAsync();

            return niveau;
        }

        private bool NiveauExists(int id)
        {
            return _context.Niveau.Any(e => e.Id == id);
        }
    }
}
