using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildToParentToChild
{
    internal class CommercialBank : FinancialIntermediary
    {
        string _name;
        public Asset asset;
        StockMarket _stockMarket;
        CryptoExchange _cryptoExchange;

        public string Name { get { return _name; } set { _name = value; } }
        public StockMarket StockMarket { get { return _stockMarket; } set { _stockMarket = value; } }
        public CryptoExchange CryptoExchange { get { return _cryptoExchange; } set { _cryptoExchange = value; } }

        public void BuyStock(string assetName)
        {
            asset = base.BuyAsset(assetName, StockMarket);
        }

        public void BuyCrypto(string assetName)
        {
            asset = base.BuyAsset(assetName, CryptoExchange);
        }
    }
}
