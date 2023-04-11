using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildParentChild
{
    internal class CommercialBank : FinancialIntermediary
    {
        public void BuyStock(string stockName)
        {
            BuyStock();
        }

        protected override void BuyStock()
        {
            base.BuyStock();
        }
    }
}
