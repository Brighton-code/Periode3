namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string? name;
            int age;

            Console.WriteLine("Please enter your name:");
            name = Console.ReadLine();

            Console.WriteLine("Please enter your age:");
            age = Convert.ToInt16(Console.ReadLine());

            if (age < 18)
            {
                Console.WriteLine("Welcome " + name + " You are too young!");
            }
            else
            {
                Console.WriteLine("Welcome " + name + " You are " + age + " years old and of age!");
            }
        }
    }
}
