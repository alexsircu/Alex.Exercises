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

        public Country GetCountry(string countryName) 
        {
            Country country = CountryList.Find(x => x.Name == countryName);
            return country;
        }

        public void CalcTotalCovidCases(object sender, CovidCaseEventArgs e)
        {
            TotalCovidPositives += e.NewCovidCase;
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
