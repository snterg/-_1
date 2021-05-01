using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ЛР_1.DAL.Data;
using ЛР_1.DAL.Entities;

namespace ЛР_1.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ЛР_1.DAL.Data.ApplicationDbContext _context;

        public IndexModel(ЛР_1.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Students
                .Include(c => c.Group).ToListAsync();
        }
    }
}
