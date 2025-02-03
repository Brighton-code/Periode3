namespace Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new()
            {
                "Anna",
                "Bob",
                "Charlie",
                "Dave",
                "Eva",
                "Frank",
                "Grace",
                "Harry",
                "Ivy",
                "Jack"
            };
            foreach (string name in names)
            {
                if (name.Length < 5)
                {
                    Console.WriteLine(name);
                }
            }

        }
    }
}
