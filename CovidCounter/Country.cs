using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidCounter
{
    internal class Country
    {
        string _name;
        int _covidPositives;

        public string Name { get => _name; set => _name = value; }
        public int CovidPositives { get => _covidPositives; set => _covidPositives = value; }

        public Country(string name)
        {
            Name = name;
        }

        public void UpdateCovidPositives(int num, TotalCovidCase totalCovidCase)
        {
            CovidPositives = 0;
            CovidPositives = num;
            totalCovidCase();
        }
    }
}
