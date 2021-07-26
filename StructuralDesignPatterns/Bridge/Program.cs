using System;

namespace Bridge
{
    interface ILanguage
    {
        string GetLanguage();
    }
    class Turkish : ILanguage
    {
        public string GetLanguage()
        {
            return "Turkish language";
        }
    }
    class English : ILanguage
    {
        public string GetLanguage()
        {
            return "English language";
        }
    }

    interface IWebPage
    {
        string GetPage();
    }
    class Home: IWebPage
    {
        private ILanguage _language { get; set;}
        public Home(ILanguage language)
        {
            _language = language;
        }
        public string GetPage()
        {
            return $"Home Page with {_language.GetLanguage()}.";
        }
    }
    class Contact : IWebPage
    {
        private ILanguage _language { get; set; }
        public Contact(ILanguage language)
        {
            _language = language;
        }
        public string GetPage()
        {
            return $"Contact Page with {_language.GetLanguage()}.";
        }
    }
    class Services : IWebPage
    {
        private ILanguage _language { get; set; }
        public Services(ILanguage language)
        {
            _language = language;
        }
        public string GetPage()
        {   
            return $"Services Page with {_language.GetLanguage()}.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Turkish turkish = new();
            English english = new();

            var homeTurkish = new Home(turkish);
            var homeEnglish = new Home(english);

            Console.WriteLine(homeTurkish.GetPage());
            Console.WriteLine(homeEnglish.GetPage());
        }
    }
}
