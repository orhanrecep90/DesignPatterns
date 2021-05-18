using System;

namespace AbstractFactory
{
    interface ITransportationVehicle
    {
        void GetSpeed();
    }
    class Train : ITransportationVehicle
    {
        public void GetSpeed()
        {
            Console.WriteLine("The train reaches 500km/h");
        }
    }
    class Plane : ITransportationVehicle
    {
        public void GetSpeed()
        {
            Console.WriteLine("The plane reaches 1300km/h");
        }
    }

    interface ITransportationStation
    {
        void DistanceToCityCenter();

    }
    class TrainStation : ITransportationStation
    {
        public void DistanceToCityCenter()
        {
            Console.WriteLine("The distance from train station to the citycentre is 10 kilometers.");
        }
    }
    class Airport : ITransportationStation
    {
        public void DistanceToCityCenter()
        {
            Console.WriteLine("The distance from airport to the citycentre is 50 kilometers.");
        }
    }
    interface ITransportationFactory
    {
        ITransportationVehicle CreateVehicle();
        ITransportationStation CreateStation();
    }
    class RailwayFactory : ITransportationFactory
    {
        public ITransportationStation CreateStation()
        {
            return new TrainStation();
        }

        public ITransportationVehicle CreateVehicle()
        {
            return new Train();
        }
    }
    class AirwayFactory : ITransportationFactory
    {
        public ITransportationStation CreateStation()
        {
            return new Airport();
        }

        public ITransportationVehicle CreateVehicle()
        {
            return new Plane();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RailwayFactory railwayFactory = new();
            ITransportationVehicle train = railwayFactory.CreateVehicle();
            ITransportationStation trainStation = railwayFactory.CreateStation();
            train.GetSpeed();
            trainStation.DistanceToCityCenter();

            AirwayFactory airwayFactory = new();
            ITransportationVehicle plane = airwayFactory.CreateVehicle();
            ITransportationStation airport = airwayFactory.CreateStation();
            plane.GetSpeed();
            airport.DistanceToCityCenter();
        }
    }
}
