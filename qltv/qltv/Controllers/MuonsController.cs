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
    public class MuonsController : ControllerBase
    {
        private readonly Vido_QltvContext _context;

        public MuonsController(Vido_QltvContext context)
        {
            _context = context;
        }

        // GET: api/Muons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Muon>>> GetMuons()
        {
            return await _context.Muons.ToListAsync();
        }

        // GET: api/Muons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Muon>> GetMuon(int id)
        {
            var muon = await _context.Muons.FindAsync(id);

            if (muon == null)
            {
                return NotFound();
            }

            return muon;
        }

        // PUT: api/Muons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuon(int id, Muon muon)
        {
            if (id != muon.MuonId)
            {
                return BadRequest();
            }

            _context.Entry(muon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuonExists(id))
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

        // POST: api/Muons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Muon>> PostMuon(Muon muon)
        {
            _context.Muons.Add(muon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MuonExists(muon.MuonId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMuon", new { id = muon.MuonId }, muon);
        }

        // DELETE: api/Muons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMuon(int id)
        {
            var muon = await _context.Muons.FindAsync(id);
            if (muon == null)
            {
                return NotFound();
            }

            _context.Muons.Remove(muon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MuonExists(int id)
        {
            return _context.Muons.Any(e => e.MuonId == id);
        }
    }
}
