using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidCounter
{
    internal class EMA
    {
        List<Country> _countryList;
        int _totalCovidPositives;

        public List<Country> CountryList { get => _countryList; set => _countryList = value; } 
        public int TotalCovidPositives { get => _totalCovidPositives; set => _totalCovidPositives = value; }

        public EMA(List<string> countryNames)
        {
            CountryList = new List<Country>();

            foreach (string countryName in countryNames)
            {
                Country country = new Country(countryName);
                CountryList.Add(country);
            }

        }

        public void CalcTotalCovidCases()
        {
            TotalCovidPositives = 0;

            foreach (Country country in CountryList)
            {
                TotalCovidPositives += country.CovidPositives;
            }
        }

        public void UpdateCovidPositives(string countryName, int num, TotalCovidCase totalCovidCase)
        {
            Country country = CountryList.Find(x => x.Name == countryName);
            country.UpdateCovidPositives(num, totalCovidCase);
        }

        public void GetCountriesCovidPositives()
        {
            foreach (Country country in CountryList)
            {
                Console.WriteLine(country.CovidPositives);
            }
        }
    }
}
