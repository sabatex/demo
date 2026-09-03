using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebChess.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Response.Cookies.Append("chessStatus", "true");
            //var a = HttpContext.Request.Cookies;
            //if (a.Count == 0)
            //{
            //    a.Append(new KeyValuePair<string, string>("chessStatus", "true"));
            //}

        }
    }
}
