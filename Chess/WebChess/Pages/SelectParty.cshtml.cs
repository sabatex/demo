using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebChess.Data;

namespace WebChess.Pages
{
    [Authorize]
    public class SelectPartyModel : PageModel
    {
        [BindProperty]
        public int SelectedParty { get; set; }

        [BindProperty]
        public bool IsNew { get; set; }
        public ChessParty[] MyParties { get; set; }
        public ChessParty[] EnabledParties { get; set; }
        ApplicationDbContext dbContext;
        public SelectPartyModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        
        public async Task OnGet()
        {
            MyParties = await dbContext.ChessParties.Where(s => s.User1 == User.Identity.Name).ToArrayAsync();
            EnabledParties = await dbContext.ChessParties.Where(s => s.User1 != User.Identity.Name && s.User2 == null).ToArrayAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (IsNew)
                {
                    var game = new ChessParty()
                    {
                        StartDate = DateTime.Now,
                        User1 = User.Identity.Name
                    };
                    dbContext.ChessParties.Add(game);
                    await dbContext.SaveChangesAsync();
                    Response.Cookies.Append("party", game.Id.ToString());
                    return RedirectToPage("/Chess");

                }
                else
                {

                }

            }
            return Page();
        }

    }
}