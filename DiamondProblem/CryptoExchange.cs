using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildToParentToChild
{
    internal class CryptoExchange : CryptoIntermediary
    {
        protected override Asset BuyAsset(string assetName, FinancialIntermediary to)
        {
            return new Crypto(assetName);
        }

        internal class Crypto : Asset
        {
            public Crypto(string name) : base(name)
            {

            }
        }
    }
}
