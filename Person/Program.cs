using System.Reflection;

namespace Person
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new ();
            Person person2 = new ("Person2", 10);
            //person2.Talk();
            person2.PrintInfo("age");



            //Console.Write("What is your name: ");
            //person.Name = Console.ReadLine();
            //Console.Write("What is your age: ");
            //try
            //{
            //    person.Age = Convert.ToInt32(Console.ReadLine());
            //    person.Talk();
            //    person.PrintInfo();
            //    person.PrintInfo("Name");
            //}
            //catch (ArgumentOutOfRangeException ex) { Console.WriteLine($"Age cannot be under 0 or above 150. Your input is {ex.ParamName}"); }
            //catch (FormatException ex) { Console.WriteLine(ex.Message); }
        }
    }

    /**
     * |--------------------|
     * |       Person       |
     * |--------------------|
     * |- _name:    string  |
     * |- _age:     int     |
     * |+ Name:     string  |
     * |+ Age:      int     |
     * |--------------------|
     * |+ Talk():   void    |
     * |--------------------|
     */
    internal class Person
    {
        private string _name = string.Empty;
        private int _age = 0;

        public string Name { 
            get => _name; 
            set => _name = value; 
        }
        
        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 150)
                    throw new ArgumentOutOfRangeException(value.ToString());
                _age = value;
            }
        }

        public Person()
        {
            Name = string.Empty;
            Age = 0;
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Talk()
        {
            Console.WriteLine($"My name is {_name} i am {_age} years old");
        }

        public void PrintInfo()
        {
            Console.WriteLine($"My name is {_name}");
        }
        public void PrintInfo(string prop)
        {
            //Console.WriteLine(this.GetType().GetProperties().Length);
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                //Console.WriteLine(property.Name); 
                if (property.Name.ToLower() == prop.ToLower())
                {
                    Console.WriteLine($"{property.Name} = {property.GetValue(this, null)}");
                    return;
                }
            }
            //Console.WriteLine("No property with this name");
            //Console.WriteLine(this.GetType().GetRuntimeProperty("Name").Name.ToString());
            //Console.WriteLine(this.GetType().GetProperty('Name', BindingFlags.Public));
            //Console.WriteLine(this.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Public));
            //Console.WriteLine(this.GetType().GetFields(BindingFlags.GetProperty | BindingFlags.Public));
            //Console.WriteLine(typeof(Person).GetProperties());
            //this.GetType().GetProperty(prop);
            //if (this.GetType().GetProperty(prop) != null)
            //    Console.WriteLine($"My name is {this.GetType().GetProperty(prop)}");
            //Console.WriteLine("No property with this name");
        }
    }
}
