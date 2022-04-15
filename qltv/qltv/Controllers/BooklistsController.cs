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
    public class BooklistsController : ControllerBase
    {
        private readonly Vido_QltvContext _context;

        public BooklistsController(Vido_QltvContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booklist>>> Search(string search)
        {

            int namxb;
            bool success = Int32.TryParse(search, out namxb);
    

            if (search == null)
            {
                return await _context.Booklists.ToListAsync();
            }

            if (!success)
            {
                namxb = 0;
            }
          


            return  await _context.Booklists
                             .Where(p => p.Tensach.Contains(search) ||
                                         p.Tentacgia.Contains(search) ||
                                         p.Tentheloai.Contains(search) ||
                                         p.Tenxuatban.Contains(search) ||
                                         p.Masach.Contains(search) ||   
                                         p.NamXb == namxb ||
                                         p.Soke.Contains(search))
                             .ToListAsync();
                             
        }

    }
}
