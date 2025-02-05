using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Menu
    {
        public void Options()
        {
            Console.WriteLine("Main Menu\n");
            Console.WriteLine("Avaiable programs:");

            Console.WriteLine(" - Program Age checker (1)");
            Console.WriteLine(" - Program Score handler (2)");
            Console.WriteLine(" - Program Find random number (3)");
            Console.WriteLine(" - Program Fizz Buzz (4)");
            Console.WriteLine(" - Program Quiz (5)");
            Console.WriteLine(" - Program Calculator (6)");
            Console.WriteLine(" - Exit (7)");

            Console.WriteLine("\nTo choose a program type the number behind the progam: \n");
        }
    }
}
