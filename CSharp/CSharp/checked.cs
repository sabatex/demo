using System;
using System.Collections.Generic;
using System.Text;


namespace CSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class OverFlowTest
    {
         // Set maxIntValue to the maximum value for integers.
        static int maxIntValue = 2147483647;
        
        // Using a checked expression.
        static int CheckedMethod()
        {

            var mot = new Random();
            mot.NextDouble();

            int z = 0;
            try
            {
                // The following line raises an exception because it is checked.
                z = checked(maxIntValue + 10); //100000000
            }
            catch (System.OverflowException e)
            {
                // The following line displays information about the error.
                System.Console.WriteLine("CHECKED and CAUGHT:  " + e.ToString());
            }
            // The value of z is still 0.
            return z;
        }

        // Using an unchecked expression.
        static int UncheckedMethod()
        {
            int z = 0;
            try
            {
                // The following calculation is unchecked and will not
                // raise an exception.
                z = maxIntValue + 10;
            }
            catch (System.OverflowException e)
            {
                // The following line will not be executed.
                System.Console.WriteLine("UNCHECKED and CAUGHT:  " + e.ToString());
            }
            // Because of the undetected overflow, the sum of 2147483647 + 10 is
            // returned as -2147483639.
            return z;
        }

        static double CallPay(int days, double cost)
        {
            if (days > 31 || days < 0)
                throw new MyException($"{days} days mast by less 31 or hiter -1");
            return days * cost;
        }

        static void Main1()
        {


            System.Console.WriteLine("\nCHECKED output value is: {0}",
                              CheckedMethod());
            System.Console.WriteLine("UNCHECKED output value is: {0}",
                              UncheckedMethod());
        }
        /*
       Output:
       CHECKED and CAUGHT:  System.OverflowException: Arithmetic operation resulted
       in an overflow.
          at ConsoleApplication1.OverFlowTest.CheckedMethod()

       CHECKED output value is: 0
       UNCHECKED output value is: -2147483639
     */
    }
}
