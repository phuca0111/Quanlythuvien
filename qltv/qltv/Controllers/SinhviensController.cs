﻿#nullable disable
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
    public class SinhviensController : ControllerBase
    {
        private readonly Vido_QltvContext _context;

        public SinhviensController(Vido_QltvContext context)
        {
            _context = context;
        }

        // GET: api/Sinhviens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sinhvien>>> Search(string search)
        {
            if (search == null)
            {
                return await _context.Sinhviens.ToListAsync();
            }

            return  await _context.Sinhviens
                             .Where(p => p.Masosinhvien.Contains(search) ||
                                         p.Tensinhvien.Contains(search) ||
                                         p.Diachi.Contains(search) ||
                                         p.Lop.Contains(search) ||
                                         p.Email.Contains(search) ||
                                         p.SoCmnd.Contains(search)||
                                         p.Khoa.Contains(search))
                             .ToListAsync();
        }

        // GET: api/Sinhviens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sinhvien>> GetSinhvien(int id)
        {
            var sinhvien = await _context.Sinhviens.FindAsync(id);

            if (sinhvien == null)
            {
                return NotFound();
            }

            return sinhvien;
        }

        // PUT: api/Sinhviens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinhvien(int id, Sinhvien sinhvien)
        {
            if (id != sinhvien.SinhvienId)
            {
                return BadRequest();
            }

            _context.Entry(sinhvien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinhvienExists(id))
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

        // POST: api/Sinhviens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sinhvien>> PostSinhvien(Sinhvien sinhvien)
        {
            _context.Sinhviens.Add(sinhvien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SinhvienExists(sinhvien.SinhvienId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSinhvien", new { id = sinhvien.SinhvienId }, sinhvien);
        }

        // DELETE: api/Sinhviens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinhvien(int id)
        {
            var sinhvien = await _context.Sinhviens.FindAsync(id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            _context.Sinhviens.Remove(sinhvien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SinhvienExists(int id)
        {
            return _context.Sinhviens.Any(e => e.SinhvienId == id);
        }
    }
}
