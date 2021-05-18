using System;
using System.Collections.Generic;

namespace Builder
{
    public enum EnumMeal
    {
        Breakfast,
        Lunch,
        Dinner
    }
    public enum EnumDirection
    {
        Sea,
        Garden
    }
    public class Room
    {
        public Room()
        {
            Meals = new List<EnumMeal>();
        }
        public int Bed { get; set; }
        public EnumDirection Direction { get; set; }
        public List<EnumMeal> Meals { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            var meals = "";
            Meals.ForEach(x =>
            {
                meals += $"{x},";
            });

            return $"Bed Count: {Bed}, Room Direction: {Direction}, Meals: {meals} Price: {Price}$";
        }
    }
    public interface IBuilder
    {
        void SetRoomSize();

        void SetRoomDirection();

        void AddMeal();
        void SetPrice();
        void Reset();
        Room GetRoom();
    }
    public class FullBoardDeluxeRoomBuilder : IBuilder
    {
        private Room _room;
        public Room Book()
        {
            return _room;
        }

        public void AddMeal()
        {
            _room.Meals.Add(EnumMeal.Breakfast);
            _room.Meals.Add(EnumMeal.Lunch);
            _room.Meals.Add(EnumMeal.Dinner);
        }

        public void SetRoomDirection()
        {
            _room.Direction = EnumDirection.Sea;
        }

        public void SetRoomSize()
        {
            _room.Bed = 5;
        }

        public void SetPrice()
        {
            _room.Price = 100;
        }

        public void Reset()
        {
            _room = new Room();
        }

        public Room GetRoom()
        {
            return _room;
        }
    }
    public class HalfBoardStandartRoomBuilder : IBuilder
    {
        private Room _room;
        public Room Book()
        {
            return _room;
        }

        public void AddMeal()
        {
            _room.Meals.Add(EnumMeal.Breakfast);
            _room.Meals.Add(EnumMeal.Dinner);
        }

        public void SetRoomDirection()
        {
            _room.Direction = EnumDirection.Garden;
        }

        public void SetRoomSize()
        {
            _room.Bed = 2;
        }

        public void SetPrice()
        {
            _room.Price = 50;
        }

        public void Reset()
        {
            _room = new Room();
        }
        public Room GetRoom()
        {
            return _room;
        }
    }

    public class Director
    {
        private IBuilder _builder;
        public Director(IBuilder builder)
        {
            AcceptBuilder(builder);
        }
        public Room CreateRoom()
        {
            _builder.AddMeal();
            _builder.SetPrice();
            _builder.SetRoomDirection();
            _builder.SetRoomSize();
            return _builder.GetRoom();
        }

        public void ChangeBuilder(IBuilder builder)
        {
            AcceptBuilder(builder);
        }
        private void AcceptBuilder(IBuilder builder)
        {
            _builder = builder;
            _builder.Reset();
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            var builder = new FullBoardDeluxeRoomBuilder();
            var director = new Director(builder);
            var deluxeRoom = director.CreateRoom();

            director.ChangeBuilder(new HalfBoardStandartRoomBuilder());
            var standartRoom = director.CreateRoom();

            Console.WriteLine($"Deluxe room features are {deluxeRoom}");
            Console.WriteLine($"Standart room features are {standartRoom}");

            Console.ReadKey();
        }
    }
}
