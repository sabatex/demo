using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcAllocMemoryForClassAndStructController : ControllerBase
    {
        public struct A
        {
            public int a;
        }

        public class B
        {
            public int a;
        }
        public sealed class C
        {
            public int a;
        }



        [HttpGet]
        public object Get(int count = 100000)
        {
            var start = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                var a = new A();
            }
            var str = DateTime.Now;
            for (int j = 0; j < count; j++)
            {
                var b = new B();
            }
            var tclass = DateTime.Now;
            for (int j = 0; j < count; j++)
            {
                var b = new C();
            }

            return new { structScore = (str-start).ToString(),classScore = (tclass - str).ToString(), classSealedScore= (DateTime.Now - tclass).ToString() };
        }


    }
}
