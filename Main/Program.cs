namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Quiz quiz = new(
                [
                    new Question {
                        question = "How old is Eiffel tower",
                        Items = ["140 years", "*138 years", "103 years"]
                    },
                    new Question {
                        question = "What is the capital of Canada",
                        Items = ["Toronto", "*Ottowa", "Ontario"]
                    },
                    new Question {
                        question = "What is the national food of Netherland",
                        Items = ["*Stampot", "Haring", "Poffertjes"]
                    }
                ]);

            quiz.Start();
            //menu.Options();
        }
    }
}
