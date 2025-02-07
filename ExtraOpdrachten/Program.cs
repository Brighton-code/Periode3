namespace ExtraOpdrachten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Bicycle b1 = new Bicycle();
            Bicycle b2 = new Bicycle(Lock.Locked, Color.Green, 100, 20);
            Bicycle b3 = new Bicycle();
            b3.Color = Color.Red;
            b3.Frameheight = 30;
            b3.LockBike();
            b3.Range = 10.5;

            Console.WriteLine($"Bicycle 1 status = color: {b1.Color}, status: {b1.Lock}, frame: {b1.Frameheight}, range: {b1.Range}");
            Console.WriteLine($"Bicycle 2 status = color: {b2.Color}, status: {b2.Lock}, frame: {b2.Frameheight}, range (Miles): {b2.RangeMiles}");
            Console.WriteLine($"Bicycle 3 status = color: {b3.Color}, status: {b3.Lock}, frame: {b3.Frameheight}, range: {b3.Range}");
            Console.WriteLine($"Total Bicycles create = {Bicycle.InstanceCounter}");

            Console.WriteLine($"add 10.52 and 39.21 = {Calculator.Add(10.52, 39.21)}");
            Console.WriteLine($"sub 323.12 and 42.12 = {Calculator.Sub(323.12, 42.12)}");
            Console.WriteLine($"{ConfigurationData.ApplicationName}, {ConfigurationData.Version}, {ConfigurationData.MaxUsers}");
        
            Car car1 = new Car();
            Car car2 = new Car("Toyota", "Yaris", Color.Green, "Brighton", 2006, "3A4FY48B67T544929");
            //car1.DisplayInfo();
            //car2.DisplayInfo();

            Garage g1 = new Garage("floor 1");
            Garage g2 = new Garage("floor 2");
            g2.AddCar(car2);
            //g2.DisplayList();
            W_Park wp = new W_Park();
            wp.AddGarage(g1);
            wp.AddGarage(g2);
            wp.AddCar(car1, g1.Name);
            wp.AddCar(new Car("Test", "dwa", Color.Blue, "dwadwad", 112, "dwad32133123"), g1.Name);
            wp.DisplayList();
        }
    }

    internal class Bicycle
    {
        private static int _instanceCounter;
        private Lock _lock;
        private double _range;

        public int Frameheight;
        public Color Color;

        public Lock Lock
        {
            get => _lock;
        }
        public double Range
        { 
            get => _range;
            set => _range = value;
        }
        public double RangeMiles
        {
            get
            {
                return _range * 0.621_371_192;
            }
        }
        public static int InstanceCounter { get => _instanceCounter; }

        public Bicycle()
        {
            _lock = Lock.Unlocked;
            Color = Color.Blue;
            Frameheight = 0;
            _range = 0;
            _instanceCounter++;
        }
        public Bicycle(Lock @lock, Color Color, int Frameheight, double Range)
        {
            _lock = @lock;
            this.Color = Color;
            this.Frameheight = Frameheight;
            this.Range = Range;
            _instanceCounter++;
        }

        public void LockBike()
        {
            _lock = Lock.Locked;
        }
        public void UnlockBike()
        {
            _lock = Lock.Unlocked;
        }
    }

    internal enum Lock
    {
        Locked,
        Unlocked
    }

    internal enum Color
    {
        Red,
        Green,
        Blue
    }

    internal static class Calculator
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }
        public static double Sub(double a, double b) 
        { 
            return a - b; 
        }
    }

    internal static class ConfigurationData
    {
        public const string ApplicationName = "Extra Opdrachten";
        public const string Version = "1";
        public const int MaxUsers = 10;
    }

    internal class Car
    {
        public string Brand;
        public string Type;
        public Color Color;
        public string Owner;
        public int Year;
        public string Vin;
        
        public Car()
        {
            Brand = string.Empty;
            Type = string.Empty;
            Color = Color.Red;
            Owner = string.Empty;
            Year = 0;
            Vin = string.Empty;
        }
        public Car(string brand, string type, Color color, string owner, int year, string vin)
        {
            Brand = brand;
            Type = type;
            Color = color;
            Owner = owner;
            Year = year;
            Vin = vin;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Car\n brand: {Brand}\n type: {Type}\n color: {Color}\n year: {Year}\n vin: {Vin}\n owner: {Owner}\n");
        }
    }

    internal class Garage
    {
        private List<Car> _cars = [];
        public string Name;
        public Garage(string name)
        {
            Name = name;
        }
        public void AddCar(Car car)
        {
            _cars.Add(car);
        }
        public void RemoveCar(Car car)
        {
            _cars.Remove(car);
        }

        public void DisplayList()
        {
            foreach (Car car in _cars)
            {
                car.DisplayInfo();
            }
        }
    }

    internal class W_Park
    {
        private List<Garage> _garages = [];

        public void AddGarage(Garage garage)
        {
            _garages.Add(garage);
        }
        public void RemoveGarage(Garage garage)
        {
            _garages.Remove(garage);
        }
        public void AddCar(Car car, string gName)
        {
            //Garage garage = _garages.Where(g => g.Name == gName);
            Garage garage = _garages.Find(g => g.Name == gName);
            if (garage == null)
                return;
            garage.AddCar(car);
        }
        public void DisplayList()
        {
            foreach (Garage garage in _garages)
            {
                Console.WriteLine($"Garage: {garage.Name}");
                garage.DisplayList();
            }
        }
    }
}
