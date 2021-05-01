using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ЛР_1.DAL.Data;
using ЛР_1.DAL.Entities;

namespace ЛР_1.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly ЛР_1.DAL.Data.ApplicationDbContext _context;

        public EditModel(ЛР_1.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(Course.studId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CourseExists(int id)
        {
            return _context.Students.Any(e => e.studId == id);
        }
    }
}
