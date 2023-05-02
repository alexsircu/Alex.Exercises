using System;
using System.Collections.Generic;

namespace CovidCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> countries = new List<string>() { "Italia", "Germania", "Francia", "Portogallo", "Spagna" };
            EMA ema = new EMA(countries);
            var random = new Random();

            foreach (var country in countries)
            {
                var countryObj = ema.GetCountry(country);
                countryObj.CovidPositivesChanged += new Country.CovidCaseHandler(ema.CalcTotalCovidCases);
                countryObj.CovidPositives = random.Next(1, 100000);
            }

            ema.GetCountriesCovidPositives();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Positivi totali");
            Console.WriteLine(ema.TotalCovidPositives);

            var italy = ema.GetCountry("Italia");
            italy.CovidPositives = 500;
            Console.WriteLine("Positivi totali aggiornati");
            Console.WriteLine(ema.TotalCovidPositives);
        }
    }
}
