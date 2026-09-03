using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPage.Data;

namespace RazorPage.Pages.Students
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Data.Student Student { get; set; }
        public  SelectListItem[] Schools { get; set; }
        
        private readonly RazorPage.Data.MyDbContext _context;

        public CreateModel(RazorPage.Data.MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Schools = await _context.Schools.Select(s=> new SelectListItem(s.Name, s.Id.ToString())).ToArrayAsync();
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
