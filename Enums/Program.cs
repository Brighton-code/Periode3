using System.ComponentModel;

namespace Enums
{
    internal class Program
    {
        public static int _count { get; private set; }
        static void Main(string[] args)
        {
            //Weekday day = (Weekday)time.Day; // Werkt niet omdat het maand dag is niet weekdag
            //Weekday day = (Weekday)Enum.Parse(typeof(Weekday), time.DayOfWeek.ToString());
            DateTime time = DateTime.Today.AddDays(4);
            Weekday day = (Weekday)time.DayOfWeek;
            Console.WriteLine(MessageOfTheDay(day));
        }

        enum Weekday
        {
            Sunday = 0,
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
        }

        static string MessageOfTheDay(Weekday day)
        {
            return day switch
            {
                Weekday.Monday => "It is Monday!",
                Weekday.Tuesday => "It is Tuesday!",
                Weekday.Wednesday => "It is Wednesday!",
                Weekday.Thursday => "It is Thursday!",
                Weekday.Friday => "It is Friday!",
                Weekday.Saturday => "It is Saturday!",
                Weekday.Sunday => "It is Sunday!",
                _ => "Something went really wrong!"
            };
        }
    }
}
