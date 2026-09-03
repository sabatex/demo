using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage.Data;

namespace RazorPage.Pages.Schools
{
    public class IndexModel : PageModel
    {
        private readonly RazorPage.Data.MyDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(RazorPage.Data.MyDbContext context,
                          SignInManager<IdentityUser> signInManager,
                          UserManager<IdentityUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IList<School> School { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            //if (_signInManager.IsSignedIn(User))
            //{
            //    var id =_userManager.GetUserId(User);
                //var t = await _userManager.IsInRoleAsync(await _userManager.GetUserAsync(User), "Admin");
                School = await _context.Schools.ToListAsync();
                return Page();
            //}
            //else
            //{
            //    return Redirect($"/Identity/Account/Login?returnUrl=/Schools");
            //}
        }
    }
}
