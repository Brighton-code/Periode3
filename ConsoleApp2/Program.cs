namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputString;
            double input;
            bool running = true;

            Console.WriteLine("What is de test score:");

            do
            {
                inputString = Console.ReadLine().Trim();
                try
                {
                    input = Convert.ToDouble(inputString);
                    running = false;
                    Console.WriteLine(Result(input));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, unable to parse: " + inputString);
                }
            } while (running);
        }

        private static string Result(double input)
        {
            return input switch
            {
                > 1.0 and < 4.0 => "Slecht",
                < 5.5 => "Matig",
                < 7.0 => "Voldoende",
                < 8.5 => "Goed",
                <= 10 => "Uitstekend",
                _ => "Invalid input"
            };
        }
    }
}
