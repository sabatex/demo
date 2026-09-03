using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDemo
{
    public class Director
    {
        public Builder Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
            return builder;
        }
    }
}
