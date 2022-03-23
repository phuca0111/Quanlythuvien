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
    public class TheLoaisController : ControllerBase
    {
        private readonly Vido_QltvContext _context;

        public TheLoaisController(Vido_QltvContext context)
        {
            _context = context;
        }

        // GET: api/TheLoais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheLoai>>> GetTheLoais()
        {
            return await _context.TheLoais.ToListAsync();
        }

        // GET: api/TheLoais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TheLoai>> GetTheLoai(int id)
        {
            var theLoai = await _context.TheLoais.FindAsync(id);

            if (theLoai == null)
            {
                return NotFound();
            }

            return theLoai;
        }

        // PUT: api/TheLoais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheLoai(int id, TheLoai theLoai)
        {
            if (id != theLoai.TheloaiId)
            {
                return BadRequest();
            }

            _context.Entry(theLoai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheLoaiExists(id))
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

        // POST: api/TheLoais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TheLoai>> PostTheLoai(TheLoai theLoai)
        {
            _context.TheLoais.Add(theLoai);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TheLoaiExists(theLoai.TheloaiId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTheLoai", new { id = theLoai.TheloaiId }, theLoai);
        }

        // DELETE: api/TheLoais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheLoai(int id)
        {
            var theLoai = await _context.TheLoais.FindAsync(id);
            if (theLoai == null)
            {
                return NotFound();
            }

            _context.TheLoais.Remove(theLoai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TheLoaiExists(int id)
        {
            return _context.TheLoais.Any(e => e.TheloaiId == id);
        }
    }
}
