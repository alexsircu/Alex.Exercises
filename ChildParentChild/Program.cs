using System;

namespace ChildParentChild
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StockMarket stm = new StockMarket();
            CommercialBank cmb = new CommercialBank();

            cmb.BuyStock("Tesla");
        }
    }
}
