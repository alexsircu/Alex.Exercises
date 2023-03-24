using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetFinanziari
{
    public class CryptoAsset : Asset
    {
        public CryptoAsset(string name) : base(name)
        {

        }

        //OPERATIONS
        public void BuyCrypto()
        {
            Console.WriteLine("Buy Bitcoin");
        }

        public void SellCrypto()
        {
            Console.WriteLine("Sell Bitcoin");
        }
    }
}