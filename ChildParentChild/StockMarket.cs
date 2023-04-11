using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildParentChild
{
    internal class StockMarket : FinancialIntermediary
    {
        protected static void BuyStocks()
        {
            Console.WriteLine("Ci sono");
        }
    }
}
