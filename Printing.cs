using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass9_19
{
    internal static class Printing
    {
        internal static void Print(string content)
        {
            Console.WriteLine(content);
        }

        internal static void Print()
        {
            Console.WriteLine("");
        }

        internal static string InputToLower()
        {
            string playerInput = Console.ReadLine().ToLower();
            return playerInput;
        }
    }
}
