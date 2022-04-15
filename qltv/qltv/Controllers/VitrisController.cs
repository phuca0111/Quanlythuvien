#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qltv.Models;
using qltv.Data;

namespace qltv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitrisController : ControllerBase
    {
        private readonly Vido_QltvContext _context;

        public VitrisController(Vido_QltvContext context)
        {
            _context = context;
        }

        // GET: api/Vitris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vitri>>> Search(string search)
        {
            if (search == null)
            {
                return await _context.Vitris.ToListAsync();
            }

            return  await _context.Vitris
                                        .Where(p => p.Tenhang.Contains(search) ||
                                                    p.Soke.Contains(search))
                                        .ToListAsync();
        }

        // GET: api/Vitris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vitri>> GetVitri(int id)
        {
            var vitri = await _context.Vitris.FindAsync(id);

            if (vitri == null)
            {
                return NotFound();
            }

            return vitri;
        }

        // PUT: api/Vitris/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVitri(int id, Vitri vitri)
        {
            if (id != vitri.VitriId)
            {
                return BadRequest();
            }

            _context.Entry(vitri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VitriExists(id))
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

        // POST: api/Vitris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vitri>> PostVitri(Vitri vitri)
        {
            _context.Vitris.Add(vitri);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VitriExists(vitri.VitriId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVitri", new { id = vitri.VitriId }, vitri);
        }

        // DELETE: api/Vitris/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVitri(int id)
        {
            var vitri = await _context.Vitris.FindAsync(id);
            if (vitri == null)
            {
                return NotFound();
            }

            _context.Vitris.Remove(vitri);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VitriExists(int id)
        {
            return _context.Vitris.Any(e => e.VitriId == id);
        }
    }
}
