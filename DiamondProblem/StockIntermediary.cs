using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildToParentToChild
{
    internal class StockIntermediary : FinancialIntermediary
    {
        protected override Asset BuyAsset(string assetName, FinancialIntermediary to)
        {
            StockMarket stockMarket = (StockMarket)to;
            return stockMarket.BuyAsset(assetName, to);
        }
    }
}
