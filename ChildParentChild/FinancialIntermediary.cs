using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildParentChild
{
    internal abstract class FinancialIntermediary
    {
        protected virtual void BuyStock()
        {
            StockMarket.BuyStocks();
        }
    }
}
