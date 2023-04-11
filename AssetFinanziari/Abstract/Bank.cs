using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssetFinanziari.Model;

namespace AssetFinanziari.Abstract
{
    internal abstract class Bank : FinancialIntermediary
    {
        string _name;
        string _headquarter;
        string _ceo;
        string _country;
        long _code;

        public Bank(string name, string headquarter, string ceo, string country)
        {
            Name = name;
            Headquarter = headquarter;
            CEO = ceo;
            Country = country;
            Code = new Random().Next(10000, 1000000);
        }

        public string Name { get { return _name; } set { _name = value; } }
        public string Headquarter { get { return _headquarter; } set { _headquarter = value; } }
        public string CEO { get { return _ceo; } set { _ceo = value; } }
        public string Country { get { return _country; } set { _country = value; } }
        public long Code { get { return _code; } set { _code = value; } }

        public virtual bool Transfer(CommercialBank to, FIATTransferRequest data)
        {
            return false;
        }
    }
}