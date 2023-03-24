using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetFinanziari
{
    public abstract class Asset
    {
        string _name;
        decimal amount;

        public string Name { get { return _name; } set { _name = value; } }
        public decimal Amount { get { return  amount; } set { amount = value; } }

        public Asset(string name)
        {
            Name = name;
        }
    }
}