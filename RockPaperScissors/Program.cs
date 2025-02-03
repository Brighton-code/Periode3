namespace RockPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock Paper Scissors\n" +
                "Please pick one of the three options:\n" +
                "1: Rock, 2: Paper, 3: Scissors");
            int userInput;
            do
            {
                userInput = GetUserInput();
                if (userInput == 0)
                {
                    Error();
                }
            } while (userInput == 0);
            int computerInput = GetComputer();
            Console.WriteLine(Result(userInput, computerInput));
        }

        private static string Result(int user, int computer)
        {
            if (computer - user == 1 || computer - user == -2) { return "Computer has won with " + ConvertComputerInput(computer); }
            if (computer - user == -1 || computer - user == 2) { return "You won, computer chose " + ConvertComputerInput(computer); }
            return "Tie, the computer also chose " + ConvertComputerInput(computer);
        }

        private static int GetUserInput()
        {
            string userInput = Console.ReadLine().Trim().ToLower();
            return MatchUserInput(userInput);
        }

        private static int GetComputer()
        {
            Random random = new();
            return random.Next(1, 4);
        }

        private static int MatchUserInput(string userInput)
        {
            return userInput switch
            {
                "rock" or "1" => 1,
                "paper" or "2" => 2,
                "scissors" or "3" => 3,
                _ => 0
            };
        }

        private static string ConvertComputerInput(int computerInput)
        {
            return computerInput switch
            {
                1 => "rock",
                2 => "paper",
                3 => "scissors",
                _ => "error"
            };
        }

        private static void Error()
        {
            Console.WriteLine("Invalid input");
        }
    }
}
