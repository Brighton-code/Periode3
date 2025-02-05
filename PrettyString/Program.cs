namespace PrettyPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PrettyString.AddXs("Hello"));
            Console.WriteLine(PrettyString.AddStars("Hello"));
            Console.WriteLine(PrettyString.PrintRandom("Hello"));
        }
    }

    /**
    * |-----------------------------|
    * |       PrettyString          |
    * |-----------------------------|
    * |+ AddXs(string):       string|
    * |‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾             |
    * |+ AddStars(string):    string|
    * |‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾          |
    * |+ PrintRandom(string): string|
    * |‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾       |
    * |-----------------------------|
    */
    internal static class PrettyString
    {
        public static string AddXs(string str)
        {
           return $"X {str} X";
        }

        public static string AddStars(string str)
        {
            return $"* {str} *";
        }

        public static string PrintRandom(string str)
        {
            int r = Random.Shared.Next(0, 2);
            return r switch
            {
                0 => AddXs(str),
                1 => AddStars(str),
                _ => AddStars(str)
            };
        }
    }
}
