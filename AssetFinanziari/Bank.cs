using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetFinanziari
{
    public abstract class Bank
    {
        string _name;
        string _headquarter;
        string _ceo;
        string _country;

        public Bank(string name, string headquarter, string ceo, string country)
        {
            Name = name;
            Headquarter = headquarter;
            CEO = ceo;
            Country = country;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public string Headquarter { get { return _headquarter; } set { _headquarter = value; } }
        public string CEO { get { return _ceo; } set { _ceo = value; } }
        public string Country { get { return _country; } set { _country = value; } }
    }
}