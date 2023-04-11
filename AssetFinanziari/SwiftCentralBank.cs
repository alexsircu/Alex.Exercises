using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssetFinanziari.Abstract;
using AssetFinanziari.Interface;

namespace AssetFinanziari
{
    internal class SwiftCentralBank : CentralBank, ISwiftSystem
    {
        /*string _BICNumber;

        public string BICNumber { get { return _BICNumber; } set { _BICNumber = value; } }*/

        public SwiftCentralBank(string name, string headquarter, string ceo, string country) : base(name, headquarter, ceo, country)
        {

        }

        //SWIFT CONTRACT
        /*public void CreateBICNumber()
        {
            BICNumber = "230432452432";
        }*/
    }
}