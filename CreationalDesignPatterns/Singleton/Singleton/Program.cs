using System;
using System.Collections.Generic;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance1 = Singleton.GetInstance();
            var instance2 = Singleton.GetInstance();

            Console.WriteLine($"instance1 and instance2 are equal = {Equals(instance1, instance2)} ");
            Console.ReadLine();
        }

    }
    public class Singleton
    {
        static Singleton instance;
        private static object locker = new object();

        private Singleton()
        {
        }

        public static Singleton GetInstance()
        {

            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }
}
