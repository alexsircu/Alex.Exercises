using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetFinanziari
{
    public class SwiftCentralBank : Bank, ISwiftSystem
    {
        CommercialBank _commercialBank;
        string _BICNumber;

        public CommercialBank CommercialBank { get { return _commercialBank; } set { _commercialBank = value; } }
        public string BICNumber { get { return _BICNumber; } set { _BICNumber = value; } }

        public SwiftCentralBank(string name, string headquarter, string ceo, string country) : base(name, headquarter, ceo, country)
        {

        }

        //ADD
        public void AddCommercialBank(CommercialBank commercialBank)
        {
            CommercialBank = commercialBank;
            CommercialBank.BICNumber = "30472034092384";
        }

        //REMOVE
        public void RemoveCommercialBank(CommercialBank commercialBank)
        {
            if (commercialBank == CommercialBank) CommercialBank = null;
        }

        //SWIFT CONTRACT
        public void CreateBICNumber()
        {
            BICNumber = "230432452432";
        }
    }
}