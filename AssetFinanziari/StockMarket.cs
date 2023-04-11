using AssetFinanziari.Abstract;
using AssetFinanziari.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetFinanziari
{
    internal class StockMarket : FinancialIntermediary
    {
        string _name;
        string _country;
        string _headquarter;
        string _address;
        string _ceo;
        TimeSpan _openingTime;
        TimeSpan _closingTime;
        StockAsset[] _stockAssets;
        CommercialBank[] _commercialBanks;

        public string Name { get { return _name; } set { _name = value; } }
        public string Country { get { return _country; } set { _country = value; } }
        public string Headquarter { get { return _headquarter; } set { _headquarter = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string CEO { get { return _ceo; } set { _ceo = value; } }
        public TimeSpan OpeningTime { get { return _openingTime; } set { _openingTime = value; } } 
        public TimeSpan ClosingTime { get { return _closingTime; } set { _closingTime = value; } } 
        public StockAsset[] StockAssets { get { return _stockAssets; } set { _stockAssets = value; } }
        public CommercialBank[] CommercialBanks { get { return _commercialBanks; } set { _commercialBanks = value; } }

        public StockMarket(string name, string country, string headquarter, string address, string ceo)
        {
            Name = name;
            Country = country;
            Headquarter = headquarter;
            Address = address;
            CEO = ceo;
            OpeningTime = TimeSpan.Parse("9:00");
            ClosingTime = TimeSpan.Parse("17:30");
            StockAssets = new StockAsset[0];
            CommercialBanks = new CommercialBank[0];
        }

        //ADD
        //TODO: Stocks are created in StockMarket and a different Obj (StockAssedBuyed) is passed to the AccountBank
        public void CreateStockAsset(string assetName, int quantity, decimal value)
        {
            StockAsset stock = StockAsset.Create(assetName, quantity, value);
            AddStockAsset(stock);
        }

        private void AddStockAsset(StockAsset stock)
        {
            StockAsset[] temporaryArray = new StockAsset[StockAssets.Length + 1];
            Array.Copy(StockAssets, temporaryArray, StockAssets.Length);
            StockAssets = temporaryArray;
            StockAssets[StockAssets.Length - 1] = stock;

            stock.AddStockMarket(this);
        }

        public void AddCommercialBank(CommercialBank commercialBank)
        {
            CommercialBank[] temporaryArray = new CommercialBank[CommercialBanks.Length + 1];
            Array.Copy(CommercialBanks, temporaryArray, CommercialBanks.Length);
            CommercialBanks = temporaryArray;
            CommercialBanks[CommercialBanks.Length - 1] = commercialBank;

            commercialBank.AddStockMarket(this);
        }

        protected override Asset BuyAsset(string assetName, decimal amount, StockMarket stockMarket)
        {
            StockAsset stockAsset = FindStockAsset(assetName);
            if (stockAsset is null) return null;

            return stockAsset;

            /*StockAssetBuyed stockAssetBuyed = new StockAssetBuyed(stockAsset.Name, stockAsset.Value, stockAsset.Quantity, amount, stockAsset.Value); 
            return stockAssetBuyed;*/
        }

        private StockAsset FindStockAsset(string assetName)
        {
            StockAsset stockAsset = Array.Find(StockAssets, stock => stock.Name == assetName);
            return stockAsset;
        }

        //STOCK ASSET
        internal class StockAsset : Asset
        {
            decimal _value;
            int _quantity;
            StockMarket _stockMarket;

            public decimal Value { get { return _value; } set { _value = value; } }
            public int Quantity { get { return _quantity; } set { _quantity = value; } }
            public decimal TotalValue { get { return Value * Quantity; } }
            public StockMarket StockMarket { get { return _stockMarket; } set { _stockMarket = value; } }
            public decimal QuantityStockBuyed { get { return Amount / Value; } }

            public StockAsset(string name, int quantity, decimal value) : base(name)
            {
                Name = name;
                Quantity = quantity;
                Value = 120M;
                //Value = value;
                //Quantity = quantity;
            }

            public static StockAsset Create(string assetName, int quantity, decimal value)
            {
                return new StockAsset(assetName, quantity, value);
            }

            public void AddStockMarket(StockMarket stockMarket)
            {
                StockMarket = stockMarket;
            }

            //OPERATIONS
            public void BuyStock()
            {
                Console.WriteLine("Buy Tesla Stock");
            }

            public void SellStock()
            {
                Console.WriteLine("Sell Tesla Stock");
            }
        }
    }
}
