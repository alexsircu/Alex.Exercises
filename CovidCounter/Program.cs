using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CovidCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> countries = new List<string>() { "Italia", "Germania", "Francia", "Portogallo", "Spagna" };
            EMA ema = new EMA(countries);
            TotalCovidCase totalCovidCaseDelegate = ema.CalcTotalCovidCases;
            var random = new Random();

            foreach (var country in countries)
            {
                ema.UpdateCovidPositives(country, random.Next(1, 100000), totalCovidCaseDelegate);
            }

            ema.GetCountriesCovidPositives();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Positivi totali");
            Console.WriteLine(ema.TotalCovidPositives);

            ema.UpdateCovidPositives("Italia", random.Next(1, 100000), totalCovidCaseDelegate);
            Console.WriteLine("Positivi totali aggiornati");
            Console.WriteLine(ema.TotalCovidPositives);
        }
    }

    public delegate void TotalCovidCase();
}
