using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage.Pages
{
    public class IndexModel : PageModel
    {
        public struct A
        {
            public int a;
        }

        public sealed class B
        {
            public int a;
        }


        private readonly ILogger<IndexModel> _logger;

        public TimeSpan StructTime;
        public  TimeSpan ClassTime;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var start = DateTime.Now;
            for (int i = 0; i < 1000000; i++)
            {
                var a = new A();
            }
            var str = DateTime.Now;
            StructTime = str - start;
            for (int j = 0; j < 1000000; j++)
            {
                var b = new B();
            }
            ClassTime = DateTime.Now - str;

        }
    }
}
