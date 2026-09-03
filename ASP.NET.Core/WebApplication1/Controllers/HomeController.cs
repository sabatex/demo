using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public struct A
    {
        public int a;
    }
     
        public sealed class  B
        {
            public int a;
        }


    public class HomeController : Controller
    {
 
        private readonly ILogger<HomeController> _logger=null;
        private readonly SimpleService simpleService;

        public static int Number;

        static HomeController()
        {
            Number = 0;
        }

        public HomeController(ILogger<HomeController> logger,SimpleService simpleService)
        {
            _logger = logger;
            this.simpleService = simpleService;
            Number++;
            var start = DateTime.Now;
            for (int i = 0; i < 1000000; i++)
            {
                var a = new A();
            }
            var str = DateTime.Now;
            var strTime = str - start;
            for (int j = 0; j < 1000000; j++)
            {
                var b = new B();
            }
            var classTime = DateTime.Now - str;
            var end = 0;

        }

        public IActionResult Index(int? id)
        {
            simpleService.MyService = "Ви заходили на сторінку студенти";
            _logger.LogWarning("Сюди не ходи");
            ViewData["MyData"] = DateTime.Now;
            if (id != null)
            {
                return View("Index2");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
