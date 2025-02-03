namespace Quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Quiz quiz = new Quiz()
            {
                questions =
                [
                    new Question {
                        question = "How old is Eiffel tower",
                        items = ["140 years", "*138 years", "103 years"]
                    },
                    new Question {
                        question = "What is the capital of Canada",
                        items = ["Toronto", "*Ottowa", "Ontario"]
                    },
                    new Question {
                        question = "What is the national food of Netherland",
                        items = ["*Stampot", "Haring", "Poffertjes"]
                    }
                ]
            };

            quiz.questions.ForEach(question =>
            {
                Console.WriteLine(question.question);
                int answer = 0;
                question.items.Shuffle();
                for (int i = 0; i < question.items.Count; i++)
                {
                    if (question.items[i][0] == '*')
                    {
                        question.items[i] = question.items[i][1..];
                        answer = i+1;
                    }
                    Console.WriteLine($" - {question.items[i]} ({i + 1})");
                }

                int userInput;
                while (true)
                {
                    Console.Write($"Your answer ({string.Join(",", Enumerable.Range(1, question.items.Count).ToList())}): ");
                    userInput = UserInput();
                    
                    if (userInput < 1 || userInput > question.items.Count)
                    {
                        continue;
                    }
                    break;
                }

                string feedback = "Incorrect!";
                if (answer == userInput)
                {
                    quiz.score++;
                    feedback = "Correct";
                }
                Console.WriteLine($"{feedback}\n");
            });
            Console.WriteLine($"Your Score is {quiz.score}/{quiz.questions.Count}");


            /**
             * Quiz structure 
             * - List
             *  - Tuple
             *   - Question
             *   - Answers (Tuple)
             *    - List<string> of answers
             *    - Correct answer index
             */
            //List<Tuple<string, Tuple<List<string>, int>>> quiz = new()
            //{
            //    Tuple.Create("How old is Eiffel tower", Tuple.Create(new List<string> {"140 years", "138 years", "103 years" }, 2)),
            //    Tuple.Create("What is the capital of Canada", Tuple.Create(new List<string> {"Toronto", "Ottowa", "Ontario" }, 2)),
            //    Tuple.Create("What is the national food of Netherland", Tuple.Create(new List<string> {"Stampot", "Haring", "Poffertjes" }, 1)),
            //};
            //int score = 0;

            //Console.WriteLine("Welcome to the Quiz!");
            //Console.WriteLine("Please enter the number behind the answers to submit as answer!\n");

            //foreach (Tuple<string, Tuple <List<string>, int>> question in quiz)
            //{
            //    Console.WriteLine(question.Item1);
            //    for (int i = 0; i < question.Item2.Item1.Count; i++)
            //    {
            //        Console.WriteLine($" - {question.Item2.Item1[i]} ({i+1})");
            //    }

            //    // User input handeling
            //    int userInput;
            //    do
            //    {
            //        Console.Write("Your answer (1,2,3): ");
            //        userInput = UserInput();
            //    } while (userInput < 1 || userInput > 3);


            //    // Score handeling
            //    if (userInput == question.Item2.Item2)
            //    {
            //        Console.WriteLine("Correct\n");
            //        score++;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Incorrect\n");
            //    }
            //}

            //Console.WriteLine($"Your Score is {score}/{quiz.Count}");
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
    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Shared.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public class Quiz
    {
        public List<Question> questions { get; set; }
        public int score = 0;
    }

    public class Question
    {
        public string question { get; set; }
        public List<string> items { get; set; }
    }
}
