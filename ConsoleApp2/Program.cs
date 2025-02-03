namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputString = string.Empty;
            int input;
            bool running = true;

            Console.WriteLine("What is de test score:");

            do
            {
                inputString = Console.ReadLine().Trim();
                try
                {
                    input = Convert.ToInt32(inputString);
                    running = false;
                    Console.WriteLine(Result(input));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, unable to parse: " + inputString);
                }
            } while (running);
        }

        private static string Result(int input)
        {
            return input switch
            {
                <= 3 => "Slecht",
                <= 5 => "Matig",
                <= 7 => "Voldoende",
                <= 9 => "Goed",
                <= 10 => "Uitstekend",
                _ => "Invalid input"
            };
        }
    }
}
