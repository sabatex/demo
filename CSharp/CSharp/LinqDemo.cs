using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp;

internal class LinqDemo
{
    static void Go(string[] args)
    {
        int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 3, 4, 2 };
        // 2.Query creation.
        // numQuery is an IEnumerable<int>
        var numQuery =
                from num in numbers
                where (num % 2) == 0
                orderby num ascending
                select num;

        var s = new string[] { };


        foreach (int num in numQuery)
        {
            Console.Write("{0,1} ", num);
        }

    }
}
