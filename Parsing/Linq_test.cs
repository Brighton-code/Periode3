using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public class Linq_test
    {
        User[] users;
        public Linq_test() 
        {
            users =
            [
                new User { Name = "John", Password = "12345678"},
                new User { Name = "Jane", Password = "password"}
            ];
        }
        public void Run()
        {
            string searchTerm = "j";

            Console.WriteLine("Hello World");
            users
                .Where(u => u.Name.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))
                .ToList()
                .ForEach(u => Console.WriteLine(u.Name));
        }
    }
}
