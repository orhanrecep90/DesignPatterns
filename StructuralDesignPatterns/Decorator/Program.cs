using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine();
            var car = new Car("WW", "Golf", 20000m);
            Console.WriteLine($"Price:{car.GetPrice()}"); 
            Console.WriteLine(car.GetFeatures());
            Console.WriteLine();

            var starterPackageCar = new Starter(car);
            Console.WriteLine($"Price:{starterPackageCar.GetPrice()}");
            Console.WriteLine(starterPackageCar.GetFeatures());
            Console.WriteLine();

            var comfortPackageCar = new Comfort(starterPackageCar);
            Console.WriteLine($"Price:{comfortPackageCar.GetPrice()}");
            Console.WriteLine(comfortPackageCar.GetFeatures());
            Console.WriteLine();

            var premiumPackageCar = new Premium(comfortPackageCar);
            Console.WriteLine($"Price:{premiumPackageCar.GetPrice()}");
            Console.WriteLine(premiumPackageCar.GetFeatures());
            Console.ReadLine();
        }
    }
    public interface ICar
    {
        decimal GetPrice();
        string GetFeatures();
    }
    public class Car : ICar
    {
        private string _brand { get; set; }
        private string _model { get; set; }
        private decimal _price { get; set; }
        public Car(string brand, string model, decimal price)
        {
            _brand = brand;
            _model = model;
            _price = price;
        }

        public string GetFeatures()
        {
            return $" Brand:{_brand}, Model:{_model},";
        }

        public decimal GetPrice()
        {
            return _price;
        }
    }
    public class Starter : ICar
    {
        private readonly ICar _car;
        public Starter(ICar car)
        {
            _car = car;
        }
        public string GetFeatures()
        {
            return $"{_car.GetFeatures()} \n *App Connect, \n *Led Headlights,";
        }

        public decimal GetPrice()
        {
            return _car.GetPrice() + 2000m;
        }
    }
    public class Comfort : ICar
    {
        private readonly ICar _car;
        public Comfort(ICar car)
        {
            _car = car;
        }
        public string GetFeatures()
        {
            return $"{_car.GetFeatures()} \n *Front Assist, \n *Panoramic Sunroof,";
        }

        public decimal GetPrice()
        {
            return _car.GetPrice() + 3000m;
        }
    }
    public class Premium : ICar
    {
        private readonly ICar _car;
        public Premium(ICar car)
        {
            _car = car;
        }
        public string GetFeatures()
        {
            return $"{_car.GetFeatures()} \n *Leather Seating Surfaces, \n *Ventilated Seats,";
        }

        public decimal GetPrice()
        {
            return _car.GetPrice() + 4500m;
        }
    }

}


