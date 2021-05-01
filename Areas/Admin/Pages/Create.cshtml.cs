using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ЛР_1.DAL.Data;
using ЛР_1.DAL.Entities;

namespace ЛР_1.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ЛР_1.DAL.Data.ApplicationDbContext _context;

        public CreateModel(ЛР_1.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
