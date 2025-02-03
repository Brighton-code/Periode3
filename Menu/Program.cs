namespace Menu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {
            bool game = true;
            do
            {
                Console.WriteLine("Main Menu\n");
                Console.WriteLine("Avaiable programs:");

                Console.WriteLine(" - Program Age checker (1)");
                Console.WriteLine(" - Program Score handler (2)");
                Console.WriteLine(" - Program Find random number (3)");
                Console.WriteLine(" - Program Fizz Buzz (4)");
                Console.WriteLine(" - Program Quiz (5)");
                Console.WriteLine(" - Program Quiz (6)");
                Console.WriteLine(" - Exit (7)");

                Console.WriteLine("\nTo choose a program type the number behind the progam: \n");

                int input = UserInput();

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Age_checker();
                        break;
                    case 2:
                        Console.Clear();
                        Score_handler();
                        break;
                    case 3:
                        Console.Clear();
                        Find_number();
                        break;
                    case 4:
                        Console.Clear();
                        FizzBuzz();
                        break;
                    case 5:
                        Console.Clear();
                        Quiz();
                        break;
                    case 6:
                        Console.Clear();
                        Calculator();
                        break;
                    case 7:
                        game = false;
                        break;
                    default:
                        Console.Clear();
                        continue;
                }

                while (true)
                {
                    Console.WriteLine("\nBack to main menu press 1 to exit press 2");
                    input = UserInput();
                    if (input == 1)
                    {
                        Console.Clear();
                        game = true;
                        break;
                    }
                    else if (input == 2)
                    {
                        game = false;
                        break;
                    }
                }

            } while (game);
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

        private static void Age_checker()
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

        static void Score_handler()
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

        static void Find_number()
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

        private static void FizzBuzz()
        {
            // FizzBuzz loop
            string outputString = string.Empty;
            for (int j = 1; j <= 100; j++)
            {
                if (j % 3 == 0)
                {
                    outputString += "Fizz";
                }
                if (j % 5 == 0)
                {
                    outputString += "Buzz";
                }
                if (outputString.Length == 0)
                {
                    outputString = j.ToString();
                }
                Console.WriteLine(outputString);
                outputString = string.Empty;
            }
        }

        private static void Quiz()
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

            foreach (Tuple<string, Tuple<List<string>, int>> question in quiz)
            {
                Console.WriteLine(question.Item1);
                for (int i = 0; i < question.Item2.Item1.Count; i++)
                {
                    Console.WriteLine($" - {question.Item2.Item1[i]} ({i + 1})");
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

        private static void Calculator()
        {
            Console.WriteLine("Calculator!\n");
            Console.WriteLine("Operator allowed\n" +
                " +\n" +
                " -\n" +
                " x\n" +
                " /\n" +
                " =\n");

            int i = 0;
            List<int> numbers = new List<int>();
            while (true || numbers.Count < 2)
            {
                Console.Write($"Number {i}: ");
                numbers.Add(UserInput());


            }
        }
    }
}
