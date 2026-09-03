using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage.Data;

namespace RazorPage.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPage.Data.MyDbContext _context;

        public DetailsModel(RazorPage.Data.MyDbContext context)
        {
            _context = context;
        }

        public Data.Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
