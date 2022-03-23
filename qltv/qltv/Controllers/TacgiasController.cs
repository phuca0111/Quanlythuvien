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
    public class TacgiasController : ControllerBase
    {
        private readonly Vido_QltvContext _context;

        public TacgiasController(Vido_QltvContext context)
        {
            _context = context;
        }

        // GET: api/Tacgiums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tacgia>>> GetTacgia()
        {
            return await _context.Tacgia.ToListAsync();
        }

        // GET: api/Tacgiums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tacgia>> GetTacgia(int id)
        {
            var tacgia = await _context.Tacgia.FindAsync(id);

            if (tacgia == null)
            {
                return NotFound();
            }

            return tacgia;
        }

        // PUT: api/Tacgiums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTacgia(int id, Tacgia tacgia)
        {
            if (id != tacgia.TacgiaId)
            {
                return BadRequest();
            }

            _context.Entry(tacgia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TacgiaExists(id))
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

        // POST: api/Tacgiums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tacgia>> PostTacgia(Tacgia tacgia)
        {
            _context.Tacgia.Add(tacgia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TacgiaExists(tacgia.TacgiaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTacgia", new { id = tacgia.TacgiaId }, tacgia);
        }

        // DELETE: api/Tacgiums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTacgia(int id)
        {
            var tacgia = await _context.Tacgia.FindAsync(id);
            if (tacgia == null)
            {
                return NotFound();
            }

            _context.Tacgia.Remove(tacgia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TacgiaExists(int id)
        {
            return _context.Tacgia.Any(e => e.TacgiaId == id);
        }
    }
}
