using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildToParentToChild
{
    internal class StockMarket : StockIntermediary
    {
        StockIntermediary StockIntermediary { get; set; }

        protected override Asset BuyAsset(string assetName, FinancialIntermediary to)
        {
            return new Stock(assetName);
        }

        internal class Stock : Asset
        {
            public Stock(string name) : base(name) 
            {
                
            }
        }
    }
}
