using System;

namespace Adapter
{
    interface ISolidFat
    {
        void Melt();
    }
    class Fame : IFame
    {

    }
    interface IFame
    {
    }
    interface IEgg
    {
    }
    class Egg : IEgg
    {

    }

    class Butter : ISolidFat
    {
        public void Melt()
        {
            //Melt Process
        }

    }

    class Margarine : ISolidFat
    {
        public void Melt()
        {
            //Melt Process
        }
    }
    class Milk
    {
        public void Boil()
        {
        }
        public void BeButter()
        {
        }
    }
    class MilkAdapter : ISolidFat
    {
        private Milk _milk;
        public MilkAdapter(Milk milk)
        {
            this._milk = milk;
        }

        public void Melt()
        {
            _milk.BeButter();
            // After be butter, Melt Process
        }
    }
    class Chef
    {

        public void MakeCake( ISolidFat solidFat, IFame fame, IEgg egg )
        {

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Milk milk = new ();
            var milkAdapter = new MilkAdapter(milk);

            Chef chef = new();
            chef.MakeCake(milkAdapter, new Fame(), new Egg());
        }
    }
}
