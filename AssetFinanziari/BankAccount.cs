using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetFinanziari
{
    public class BankAccount
    {
        CommercialBank _commercialBank;
        BankClient _bankClient;
        FiatAsset _fiatAsset;
        StockAsset _stockAsset;
        CryptoAsset _cryptoAsset;

        public CommercialBank CommercialBank { get { return _commercialBank; } set { _commercialBank = value; } }
        public BankClient BankClient { get { return _bankClient; } set { _bankClient = value; } }
        public FiatAsset FiatAsset { get { return _fiatAsset; } set { _fiatAsset = value; } }
        public StockAsset StockAsset { get { return _stockAsset; } set { _stockAsset = value; } }
        public CryptoAsset CryptoAsset { get { return _cryptoAsset; } set { _cryptoAsset = value; } }

        public BankAccount(CommercialBank commercialBank, BankClient bankClient)
        {
            CommercialBank = commercialBank;
            BankClient = bankClient;
        }

        //ADD
        public void AddFiatAsset(FiatAsset fiatAsset)
        {
            FiatAsset = fiatAsset;
        }
        public void AddStockAsset(StockAsset stockAsset)
        {
            StockAsset = stockAsset;
        }
        public void AddCryptoAsset(CryptoAsset cryptoAsset)
        {
            CryptoAsset = cryptoAsset;
        }

        //FIAT OPERATIONS
        public void WithdrawFiat(decimal fiatAmount)
        {
            FiatAsset.WithdrawFiat(fiatAmount);
        }
        public void DepositFiat(decimal fiatAmount)
        {
            FiatAsset.DepositFiat(fiatAmount);
        }

        //STOCK OPERATIONS
        public void BuyStock()
        {
            StockAsset.BuyStock();
        }

        public void SellStock()
        {
            StockAsset.SellStock();
        }


        //CRYPTO OPERATIONS
        public void BuyCrypto()
        {
            CryptoAsset.BuyCrypto();
        }

        public void SellCrypto()
        {
            CryptoAsset.SellCrypto();
        }

        //FIAT TRANSFER 
        public void TransferFiat(decimal amount, BankAccount bankAccount)
        {
            bool check = FiatAsset.WithdrawFiat(amount);   
            if (check) CommercialBank.TransferFiat(bankAccount, amount);
            if (!check) Console.WriteLine("Non è possibile effettuale il bonifico. Fondi insufficienti");
        }   

    }
}