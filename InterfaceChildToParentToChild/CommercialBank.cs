using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceChildToParentToChild
{
    internal class CommercialBank : IStockIntermediary, ICryptoIntermediary
    {
        StockMarket _stockMarket;
        CryptoExchange _cryptoExchange;

        internal StockMarket StockMarket { get => _stockMarket; set => _stockMarket = value; }
        internal CryptoExchange CryptoExchange { get => _cryptoExchange; set => _cryptoExchange = value; }

        public void BuyStock()
        {
            StockMarket.BuyStock();
        }

        public void BuyCrypto()
        {
            CryptoExchange.BuyCrypto();
        }
    }
}
