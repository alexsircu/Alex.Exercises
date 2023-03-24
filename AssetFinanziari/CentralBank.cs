using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetFinanziari
{
    public class CentralBank : Bank
    {
        CommercialBank _commercialBank;

        public CommercialBank CommercialBank { get { return _commercialBank; } set { _commercialBank = value; } }

        public CentralBank(string name, string headquarter, string ceo, string country) : base(name, headquarter, ceo, country)
        {
            
        }

        //ADD
        public void AddCommercialBank(CommercialBank commercialBank)
        {
            CommercialBank = commercialBank;
        }

        //REMOVE
        public void RemoveCommercialBank(CommercialBank commercialBank)
        {
            if (commercialBank == CommercialBank) CommercialBank = null;
        }
    }
}