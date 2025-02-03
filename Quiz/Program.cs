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
