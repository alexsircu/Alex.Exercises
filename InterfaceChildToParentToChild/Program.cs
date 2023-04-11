using System;

namespace InterfaceChildToParentToChild
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommercialBank unicredit = new CommercialBank();

            unicredit.CryptoExchange = new CryptoExchange();
            unicredit.StockMarket = new StockMarket();

            unicredit.BuyCrypto();
        }
    }
}
