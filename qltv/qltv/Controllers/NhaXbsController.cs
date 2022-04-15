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
    public class NhaXbsController : ControllerBase
    {
        private readonly Vido_QltvContext _context;

        public NhaXbsController(Vido_QltvContext context)
        {
            _context = context;
        }

        // GET: api/NhaXbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhaXb>>> Search(string search)
        {
           if (search == null)
            {
                return await _context.NhaXbs.ToListAsync();
            }

            return  await _context.NhaXbs
                             .Where(p => p.Tenxuatban.Contains(search) ||
                                         p.Diachi.Contains(search) ||
                                         p.Email.Contains(search) ||
                                         p.ThongtinNguoiDaiDien.Contains(search))
                             .ToListAsync();
        }

        // GET: api/NhaXbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhaXb>> GetNhaXb(int id)
        {
            var nhaXb = await _context.NhaXbs.FindAsync(id);

            if (nhaXb == null)
            {
                return NotFound();
            }

            return nhaXb;
        }

        // PUT: api/NhaXbs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhaXb(int id, NhaXb nhaXb)
        {
            if (id != nhaXb.NhaXbid)
            {
                return BadRequest();
            }

            _context.Entry(nhaXb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhaXbExists(id))
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

        // POST: api/NhaXbs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NhaXb>> PostNhaXb(NhaXb nhaXb)
        {
            _context.NhaXbs.Add(nhaXb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NhaXbExists(nhaXb.NhaXbid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNhaXb", new { id = nhaXb.NhaXbid }, nhaXb);
        }

        // DELETE: api/NhaXbs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhaXb(int id)
        {
            var nhaXb = await _context.NhaXbs.FindAsync(id);
            if (nhaXb == null)
            {
                return NotFound();
            }

            _context.NhaXbs.Remove(nhaXb);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NhaXbExists(int id)
        {
            return _context.NhaXbs.Any(e => e.NhaXbid == id);
        }
    }
}
