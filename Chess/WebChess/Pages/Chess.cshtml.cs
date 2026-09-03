using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebChess.Data;
using WebChess.Models;

namespace WebChess.Pages
{
    [Authorize]
    public class ChessModel : PageModel
    {
        public int? Party { get; set; }
        public string InitialDesk { get; set; }

        public string  WhiteUser { get; set; }
        public string User1 { get; set; }
        public string User2 { get; set; }


        ApplicationDbContext dbContext;
        public ChessModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            Party = null;
        }

        public async Task<IActionResult> OnGet()
        {
            // check player
            if (int.TryParse(Request.Cookies.SingleOrDefault(s => s.Key == "party").Value, out int party))
            {
                var cp = await dbContext.ChessParties.SingleOrDefaultAsync(s => s.Id == party);
                if (cp != null)
                {
                    User1 = cp.User1;
                    User2 = cp.User2;
                    WhiteUser = cp.WhiteUser;
                    var parties = await dbContext.DeskStates.Where(p => p.ChessPartyId == Party).ToArrayAsync();
                    if (parties.Length != 0)
                    {
                        int last = parties.Max(s => s.Id);//.LastOrDefault();
                        var desk = await dbContext.DeskStates.SingleOrDefaultAsync(d => d.Id == last);
                        InitialDesk = System.Text.Json.JsonSerializer.Serialize(desk.Desk, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                    }
                    else
                    {
                        var desk = new ChessDesk();
                        InitialDesk = System.Text.Json.JsonSerializer.Serialize(desk, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                    }

                }

            }
            Response.Cookies.Delete("party");
            return Page();

         }

        class moveData
        {
            public int row { get; set; }
            public int column { get; set; }
            public int destinationRow { get; set; }
            public int destinationColumn { get; set; }
        }

        public JsonResult OnPostMove(string row,string column,string destinationRow, string destinationColumn)
        {

            var desk = new ChessDesk();
            return new JsonResult(desk);

            //MemoryStream stream = new MemoryStream();
            //await Request.Body.CopyToAsync(stream);
            //stream.Position = 0;
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    string requestBody = reader.ReadToEnd();
            //    if (requestBody.Length > 0)
            //    {
            //        var obj = JsonConvert.DeserializeObject<moveData>(requestBody);
            //        var col = obj.column;

            //    }
            //}

            //var a = 10;
        }

        public JsonResult OnGetDesk()
        {
            var desk = new ChessDesk();
            return new JsonResult(desk);

        }
    
        public async Task<JsonResult> OnGetGameList()
        {
            var user = User.Identity.Name;
            var result = new
            {
                myNewGame = await dbContext.ChessParties.SingleOrDefaultAsync(s => s.User1 == user && s.User2 == null),
                myGames = await dbContext.ChessParties.Where(s => s.User1 == user && s.User2 != null).ToArrayAsync(),
                myJoinGames = await dbContext.ChessParties.Where(s => s.User1 != null && s.User2 == user).ToArrayAsync(),
                waitForJoin = await dbContext.ChessParties.Where(s => s.User1 != user &&  s.User2 == null).ToArrayAsync()
            };
            return new JsonResult(result);
        }

        public async Task<JsonResult> OnGetNewGame()
        {
            var user = User.Identity.Name;
            var myNewGame = await dbContext.ChessParties.SingleOrDefaultAsync(s => s.User1 == user && s.User2 == null);
            if (myNewGame == null)
            {
                myNewGame = new ChessParty()
                {
                    User1 = user
                };
                await dbContext.ChessParties.AddAsync(myNewGame);
                await dbContext.SaveChangesAsync();
            }
            return new JsonResult(myNewGame);

        }

    }
}