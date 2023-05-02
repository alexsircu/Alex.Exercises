using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidCounter
{
    internal class Country
    {
        public delegate void CovidCaseHandler(object sender, CovidCaseEventArgs e);
        public event CovidCaseHandler CovidPositivesChanged;
        string _name;
        int _covidPositives;

        public string Name { get => _name; set => _name = value; }
        public int CovidPositives 
        { get => _covidPositives; set 
            { 
                CovidCaseEventArgs e = new CovidCaseEventArgs(value);
                CovidPositivesChanged(this, e);
                _covidPositives = value; 
            } 
        }

        public Country(string name)
        {
            Name = name;
        }
    }
}
