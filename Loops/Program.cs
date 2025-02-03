namespace Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number between 1 and 99");
            int computer = Random.Shared.Next(1, 100);
            int input;
            int i = 0;
            string output;
            do
            {
                input = UserInput();
                if (input > 99 || input < 1)
                {
                    Console.WriteLine("Invalid input, range is between 1 and 99");
                    continue;
                }
                output = HigherOrLower(input, computer);
                Console.WriteLine($"Input is {output} than Computer!");
                i++;
            } while (input != computer);
            Console.WriteLine($"You won! Amount of guesses {i}!");
        }

        private static int UserInput()
        {
            string inputString;
            int user;

            while (true)
            {
                inputString = Console.ReadLine();
                try
                {
                    user = Convert.ToInt16(inputString);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"{inputString}, not a valid input!");
                    continue;
                }
                break;
            }
            return user;
        }

        private static string HigherOrLower(int user, int computer)
        {
            if (user < computer)
            {
                return "Lower";
            }
            else if (user > computer)
            {
                return "Higher";
            }
            else if (user == computer)
            {
                return "Equel";
            }
            else
            {
                return "Invalid";
            }

        }
    }
}
