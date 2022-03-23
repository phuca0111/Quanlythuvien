#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qltv.Models;
using qltv.data;

namespace qltv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrasController : ControllerBase
    {
        private readonly Vido_QltvContext _context;

        public TrasController(Vido_QltvContext context)
        {
            _context = context;
        }

        // GET: api/Tras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tra>>> GetTras()
        {
            return await _context.Tras.ToListAsync();
        }

        // GET: api/Tras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tra>> GetTra(int id)
        {
            var tra = await _context.Tras.FindAsync(id);

            if (tra == null)
            {
                return NotFound();
            }

            return tra;
        }

        // PUT: api/Tras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTra(int id, Tra tra)
        {
            if (id != tra.TraId)
            {
                return BadRequest();
            }

            _context.Entry(tra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraExists(id))
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

        // POST: api/Tras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tra>> PostTra(Tra tra)
        {
            _context.Tras.Add(tra);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TraExists(tra.TraId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTra", new { id = tra.TraId }, tra);
        }

        // DELETE: api/Tras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTra(int id)
        {
            var tra = await _context.Tras.FindAsync(id);
            if (tra == null)
            {
                return NotFound();
            }

            _context.Tras.Remove(tra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraExists(int id)
        {
            return _context.Tras.Any(e => e.TraId == id);
        }
    }
}
