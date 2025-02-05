using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Quiz
    {
        private int _currentQuestion = 0;
        public List<Question> Questions { get; set; } = [];
        public int Score = 0;

        public Quiz(List<Question> questions)
        {
            Questions = questions;
        }

        public void Start()
        {
            while (_currentQuestion < Questions.Count)
            {
                Question question = GetQuestion();
                question.ShowQuestion();

                int input;
                while (true)
                {
                    try
                    {
                        Console.Write($"Your answer ({string.Join(",", Enumerable.Range(1, question.Items.Count).ToList())}): ");
                        input = Convert.ToInt16(Console.ReadLine());
                        if (input < 1 || input > question.Items.Count)
                            continue;
                        break;
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                }

                string feedback = "Incorrect!";
                if (question.IsAnswer(input))
                {
                    Score++;
                    feedback = "Correct";
                }
                Console.WriteLine($"{feedback}\n");
            }
            Console.WriteLine($"Quiz is over your score is {Score}/{Questions.Count}");
        }

        private Question GetQuestion()
        {
            Question tmpQuestion = Questions[_currentQuestion];
            _currentQuestion++;
            return tmpQuestion;
        }
    }
    internal class Question
    {
        public string question { get; set; } = "";
        public List<string> Items { get; set; } = [];
        private int _answer = 0;

        public void ShowQuestion()
        {
            Console.WriteLine(question + "\n");
            Items.Shuffle();
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i][0] == '*')
                {
                    Items[i] = Items[i][1..];
                    _answer = i + 1;
                }
                Console.WriteLine($" - {Items[i]} ({i + 1})");
            }
        }
        public bool IsAnswer(int input)
        {
            if (_answer == input)
                return true;
            return false;
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
}
