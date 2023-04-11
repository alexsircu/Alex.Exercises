using System;

namespace ChildToParentToChild
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommercialBank unicredit = new CommercialBank();

            unicredit.StockMarket = new StockMarket();
            unicredit.CryptoExchange = new CryptoExchange();

            unicredit.BuyCrypto("bitcoin");

            Console.WriteLine(unicredit.asset.Name);

            unicredit.BuyStock("tesla");
            Console.WriteLine(unicredit.asset.Name);
        }
    }
}
