using System;


namespace FactoryMethod
{


    interface IInterview
    {
        void AskQuestions();
    }

    class Coding : IInterview
    {
        public void AskQuestions()
        {
            Console.WriteLine("Asking about design patterns!");
        }
    }

    class Personal : IInterview
    {
        public void AskQuestions()
        {
            Console.WriteLine("Asking about candidate personal questions!");
        }
    }

    abstract class HiringManager
    {
        abstract protected IInterview MakeInterview();
        public void TakeInterview()
        {
            var interviewer = this.MakeInterview();
            interviewer.AskQuestions();
        }
    }
    class DevelopmentManager : HiringManager
    {
        protected override IInterview MakeInterview()
        {
            return new Coding();
        }
    }

    class RecruitmentManager : HiringManager
    {
        protected override IInterview MakeInterview()
        {
            return new Personal();
        }
    }
    class Expectation : IInterview
    {
        public void AskQuestions()
        {
            Console.WriteLine("Asking about expectations!");
        }
    }
    class GeneralManager : HiringManager
    {
        protected override IInterview MakeInterview()
        {
            return new Expectation();
        }
    }
    class Candidate
    {
        public void Main()
        {
            Console.WriteLine("Enter the interview with RecruitmentManager ");
            EnterTheInterview(new RecruitmentManager());
            Console.WriteLine("Enter the interview with DevelopmentManager ");
            EnterTheInterview(new DevelopmentManager());
            Console.WriteLine("Enter the interview with GeneralManager ");
            EnterTheInterview(new GeneralManager());
        }

        public void EnterTheInterview(HiringManager manager)
        {
            manager.TakeInterview();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Candidate().Main();
        }
    }
}
