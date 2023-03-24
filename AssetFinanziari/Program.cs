using System;

namespace AssetFinanziari
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            //CENTRAL SWIFT BANK--------------------------
            SwiftCentralBank bancaDItalia = new SwiftCentralBank("Banca d'Italia", "Roma","Ignazio Visco", "Italia");

            //COMMERCIAL BANK
            CommercialBank unicredit = new CommercialBank("Unicredit", "Milano", "Andrea Orcel", "Italia");
            bancaDItalia.AddCommercialBank(unicredit);

            //CLIENT
            unicredit.AddBankClient("Mario", "Rossi", 43, "maschio", "mario.rossi@gmail.com", "3287655611", "Via Torino", "Milano", "Italia");
            BankClient mario = unicredit.BankClient;

            //BANK ACCOUNT
            mario.AddBankAccount();
            BankAccount marioBankAccount = mario.BankAccount;

            //ASSET
            FiatAsset euro = new FiatAsset("Euro");
            StockAsset tesla = new StockAsset("Azioni Tesla");
            CryptoAsset bitcoin = new CryptoAsset("Bitcoin");

            marioBankAccount.AddFiatAsset(euro);
            marioBankAccount.AddStockAsset(tesla);
            marioBankAccount.AddCryptoAsset(bitcoin);

            //FIAT OPERATIONS
            marioBankAccount.DepositFiat(3700M);
            marioBankAccount.DepositFiat(12000M);
            marioBankAccount.WithdrawFiat(120M);

            //STOCK OPERATIONS
            marioBankAccount.BuyStock();
            marioBankAccount.SellStock();

            //CRYPTO OPERATIONS
            marioBankAccount.BuyCrypto();
            marioBankAccount.SellCrypto();

            //CENTRAL BANK NO SWIFT-------------------------------
            CentralBank russianCentralBank = new CentralBank("Central Bank of the the Russian Federation", "Mosca", "El'vira Nabiullina", "Russia");

            //COMMERCIAL BANK
            CommercialBank gazpromBank = new CommercialBank("Gazprombank", "Mosca", "Andrey Akimov", "Russia");
            russianCentralBank.AddCommercialBank(gazpromBank);

            //CLIENT
            gazpromBank.AddBankClient("Ivan", "Smirnov", 34, "maschio", "ivan.smirnov@gmail.com", "345563456", "Ulitsa Potylikha", "Mosca", "Russia");
            BankClient ivan = gazpromBank.BankClient;

            //BANK ACCOUNT
            ivan.AddBankAccount();
            BankAccount ivanBankAccount = ivan.BankAccount;

            //ASSET
            FiatAsset euroIv = new FiatAsset("Euro");
            StockAsset teslaIv = new StockAsset("Azioni Tesla");
            CryptoAsset bitcoinIv = new CryptoAsset("Bitcoin");

            ivanBankAccount.AddFiatAsset(euro);
            ivanBankAccount.AddStockAsset(tesla);
            ivanBankAccount.AddCryptoAsset(bitcoin);

            //BANK TRANSFER--------------------------
            marioBankAccount.TransferFiat(998M, ivanBankAccount);

            ivanBankAccount.TransferFiat(1239M, marioBankAccount);

        }
    }
}
