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
    public class ThuthusController : ControllerBase
    {
        private readonly Vido_QltvContext _context;

        public ThuthusController(Vido_QltvContext context)
        {
            _context = context;
        }

        // GET: api/Thuthus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thuthu>>> GetThuthus()
        {
            return await _context.Thuthus.ToListAsync();
        }

        // GET: api/Thuthus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thuthu>> GetThuthu(int id)
        {
            var thuthu = await _context.Thuthus.FindAsync(id);

            if (thuthu == null)
            {
                return NotFound();
            }

            return thuthu;
        }

        // PUT: api/Thuthus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThuthu(int id, Thuthu thuthu)
        {
            if (id != thuthu.ThuthuId)
            {
                return BadRequest();
            }

            _context.Entry(thuthu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuthuExists(id))
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

        // POST: api/Thuthus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Thuthu>> PostThuthu(Thuthu thuthu)
        {
            _context.Thuthus.Add(thuthu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ThuthuExists(thuthu.ThuthuId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetThuthu", new { id = thuthu.ThuthuId }, thuthu);
        }

        // DELETE: api/Thuthus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThuthu(int id)
        {
            var thuthu = await _context.Thuthus.FindAsync(id);
            if (thuthu == null)
            {
                return NotFound();
            }

            _context.Thuthus.Remove(thuthu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThuthuExists(int id)
        {
            return _context.Thuthus.Any(e => e.ThuthuId == id);
        }
    }
}
