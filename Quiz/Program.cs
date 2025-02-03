namespace Quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /**
             * Quiz structure 
             * - List
             *  - Tuple
             *   - Question
             *   - Answers (Tuple)
             *    - List<string> of answers
             *    - Correct answer index
             */
            List<Tuple<string, Tuple<List<string>, int>>> quiz = new()
            {
                Tuple.Create("How old is Eiffel tower", Tuple.Create(new List<string> {"140 years", "138 years", "103 years" }, 2)),
                Tuple.Create("What is the capital of Canada", Tuple.Create(new List<string> {"Toronto", "Ottowa", "Ontario" }, 2)),
                Tuple.Create("What is the national food of Netherland", Tuple.Create(new List<string> {"Stampot", "Haring", "Poffertjes" }, 1)),
            };
            int score = 0;

            Console.WriteLine("Welcome to the Quiz!");
            Console.WriteLine("Please enter the number behind the answers to submit as answer!\n");

            foreach (Tuple<string, Tuple <List<string>, int>> question in quiz)
            {
                Console.WriteLine(question.Item1);
                for (int i = 0; i < question.Item2.Item1.Count; i++)
                {
                    Console.WriteLine($" - {question.Item2.Item1[i]} ({i+1})");
                }

                // User input handeling
                int userInput;
                do
                {
                    Console.Write("Your answer (1,2,3): ");
                    userInput = UserInput();
                } while (userInput < 1 || userInput > 3);


                // Score handeling
                if (userInput == question.Item2.Item2)
                {
                    Console.WriteLine("Correct\n");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect\n");
                }
            }

            Console.WriteLine($"Your Score is {score}/{quiz.Count}");
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
    }
}
