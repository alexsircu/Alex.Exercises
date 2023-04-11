using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetFinanziari.Abstract
{
    internal abstract class FinancialIntermediary
    {
        protected virtual Asset BuyAsset(string assetName, decimal amount, StockMarket stockMarket) 
        {
            return stockMarket.BuyAsset(assetName, amount, stockMarket);
        }

        internal abstract class Asset
        {
            string _name;
            decimal amount;

            public string Name { get { return _name; } set { _name = value; } }
            public decimal Amount { get { return amount; } set { amount = value; } }

            public Asset(string name)
            {
                Name = name;
            }

            public virtual bool Withdraw(decimal amount)
            {
                return false;
            }

            public virtual void Deposit(decimal amount)
            {

            }
        }
    }
}
