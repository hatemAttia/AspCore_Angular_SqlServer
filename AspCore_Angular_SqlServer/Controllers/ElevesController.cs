using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspCore_Angular_SqlServer.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AspCore_Angular_SqlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevesController : ControllerBase
    {
        private readonly ElearningContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ElevesController(ElearningContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Eleves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eleve>>> GetEleve()
        {
            return await _context.Eleve.ToListAsync();
        }

        // GET: api/Eleves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eleve>> GetEleve(int id)
        {
            var eleve = await _context.Eleve.FindAsync(id);
           
            if (eleve == null)
            {
                return NotFound();
            }

            return eleve;
        }

        // PUT: api/Eleves/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEleve(int id, Eleve eleve)
        {
            if (id != eleve.Id)
            {
                return BadRequest();
            }

            _context.Entry(eleve).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EleveExists(id))
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

        // POST: api/Eleves
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Eleve>> PostEleve(Eleve eleve)
        {
            var id = 0;
            if (_context.Eleve.Count() <= 0)
            {
                id = 0;

            }
            else
            {
                id = _context.Eleve.Max(e => e.Id);

            }

            eleve.Image = "logo.png";

            eleve.Id = id + 1;
            _context.Eleve.Add(eleve);
            
          /*  if (eleve.Image != null)
            {
                string folder = "images/imgEleve";
                folder += eleve.Image.FileName + Guid.NewGuid().ToString();
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
              await  eleve.Image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            } */

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EleveExists(eleve.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEleve", new { id = eleve.Id }, eleve);
        }

        // DELETE: api/Eleves/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Eleve>> DeleteEleve(int id)
        {
            var eleve = await _context.Eleve.FindAsync(id);
            if (eleve == null)
            {
                return NotFound();
            }

            _context.Eleve.Remove(eleve);
            await _context.SaveChangesAsync();

            return eleve;
        }

        private bool EleveExists(int id)
        {
            return _context.Eleve.Any(e => e.Id == id);
        }
    }
}
