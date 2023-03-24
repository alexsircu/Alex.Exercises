using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetFinanziari
{
    public class StockAsset : Asset
    {
        public StockAsset(string name) : base(name)
        {

        }

        //OPERATIONS
        public void BuyStock()
        {
            Console.WriteLine("Buy Tesla Stock");
        }

        public void SellStock()
        {
            Console.WriteLine("Sell Tesla Stock");
        }
    }
}