using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildToParentToChild
{
    internal abstract class FinancialIntermediary
    {
        protected virtual Asset BuyAsset(string assetName, FinancialIntermediary to)
        {
            if (to is StockMarket)
            {
                StockIntermediary stockIntermediary = (StockIntermediary)to;
                return stockIntermediary.BuyAsset(assetName, to);
            } 
            
            if (to is CryptoExchange)
            {
                CryptoIntermediary cryptoIntermediary = (CryptoIntermediary)to;
                return cryptoIntermediary.BuyAsset(assetName, to);
            }

            return null;
        }

        internal class Asset
        {
            public string Name { get; set; }

            public Asset(string name)
            {
                Name = name;
            }
        }
    }
}
