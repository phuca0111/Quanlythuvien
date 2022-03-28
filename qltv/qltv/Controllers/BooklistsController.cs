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
    public class BooklistsController : ControllerBase
    {
        private readonly Vido_QltvContext _context;

        public BooklistsController(Vido_QltvContext context)
        {
            _context = context;
        }
        /*[HttpGet("GetSupplierFromBooklistname")]
        public async Task<Booklist> GetSupplierFromBooklistname(string booklistName)
        {
            return await _context.Booklists
                .Include(b => b.Tensach)
                .Where(b => b.Tensach == booklistName)
                .FirstOrDefaultAsync();
        }*/

        // GET: api/Saches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booklist>>> GetBooklists()
        {
            return await _context.Booklists.ToListAsync();
        }
        // GET: api/Muons/5
        [HttpGet("{Tensach}")]
        public async Task<ActionResult<Booklist>> GetBooklist(string Tensach)
        {
            var booklist = await _context.Booklists.FindAsync(Tensach);

            if (booklist == null)
            {
                return NotFound();
            }

            return booklist;
        }








    }
}
