using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace ch11and14hot
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("enter 0 to trigger Arithmetic Exception\nenter any non number to trigger Format Exception");
            try
            {
                int result;
                int value = Convert.ToInt32(ReadLine());
                result = 10 / value;
                WriteLine(result);
            }
            catch (ArithmeticException)
            {
                WriteLine("you triggered the Arithmetic Exception");
            }
            catch (FormatException)
            {
                WriteLine("you triggered the Format Exception");
            }

            /////try catch for invalid exception
            try
            {
                bool cool = false;
                Convert.ToChar(cool);//triggers Invalid Cast Exception
            }
            catch (InvalidCastException)
            {
                WriteLine("you triggered the Invalid Cast Exception");
            }

            ////try catch for null reference exception
            try
            {
                int[] values = null;
                for (int ctr = 0; ctr <= 9; ctr++)
                    values[ctr] = ctr * 2;

                foreach (var val in values)
                    Console.WriteLine(val);
            }
            catch (NullReferenceException)
            {
                WriteLine("you triggered the Null Reference Exception");
            }
        }
    }
  
}
