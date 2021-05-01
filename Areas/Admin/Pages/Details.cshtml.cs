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
    public class DetailsModel : PageModel
    {
        private readonly ЛР_1.DAL.Data.ApplicationDbContext _context;

        public DetailsModel(ЛР_1.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Students
                .Include(c => c.Group).FirstOrDefaultAsync(m => m.studId == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
