using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildToParentToChild
{
    internal class CryptoIntermediary : FinancialIntermediary
    {
        protected override Asset BuyAsset(string assetName, FinancialIntermediary to)
        {
            CryptoExchange cryptoExchange = (CryptoExchange)to;
            return cryptoExchange.BuyAsset(assetName, to);
        }
    }
}
