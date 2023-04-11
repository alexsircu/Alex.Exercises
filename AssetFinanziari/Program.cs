using System;
using AssetFinanziari.Model;
using AssetFinanziari.Test;

namespace AssetFinanziari
{
    internal class Program
    {
        static void Main(string[] args)
        { 

            //FILE LOG DIR AND NAME
            //string dir = "D:\\Corso-c#-CGM\\Alex.Exercises\\Log";
            //string fileName = "Operation.txt";

            //CENTRAL SWIFT BANK--------------------------
            SwiftCentralBank bancaDItalia = new SwiftCentralBank("Banca d'Italia", "Roma","Ignazio Visco", "Italia");

            //STOCK MARKET
            StockMarket piazzaAffari = new StockMarket("Piazza Affari", "Italia", "Milano", "P.za degli Affari, 6", "Raffaele Jerusalmi");

            //COMMERCIAL BANK
            CommercialBank unicredit = new CommercialBank("Unicredit", "Milano", "Andrea Orcel", "Italia");
            bancaDItalia.AddCommercialBank(unicredit);

            CommercialBank intesaSanPaolo = new CommercialBank("Intesa San Paolo", "Torino", "Andrea Orcel", "Italia");
            bancaDItalia.AddCommercialBank(intesaSanPaolo);

            //ADD STOCK MARKET
            unicredit.AddStockMarket(piazzaAffari);
            intesaSanPaolo.AddStockMarket(piazzaAffari);

            //CLIENT
            bool marioIsAdded = unicredit.AddBankClient("Mario", "Rossi", "MRARSS13S08H501H", "23/12/1998", "maschio", "mario.rossi@gmail.com", "3287655611", "Via Torino", "Milano", "Italia");
            if (!marioIsAdded) return;

            //BANK ACCOUNT
            unicredit.AddBankAccount("Mario", "Rossi", "MRARSS13S08H501H");
            long marioAccountIban = Test.Test.getIban(unicredit, "MRARSS13S08H501H");

            //BUY STOCK ASSET NO MONEY
            unicredit.BuyStockAsset("Tesla", 40000, "Euro", marioAccountIban);

            //ASSET
            unicredit.AddFiatAsset("Euro", marioAccountIban);
            unicredit.AddFiatAsset("GBP", marioAccountIban);
            unicredit.AddCryptoAsset("Bitcoin", marioAccountIban);
          
            //FIAT OPERATIONS
            //unicredit.DepositFiat("Euro", 10000M, marioAccountIban);
            //unicredit.DepositFiat("GBP", 12000M, marioAccountIban);
            //unicredit.WithdrawFiat("Euro", 4000M, marioAccountIban);
            //unicredit.WithdrawFiat("Euro", 1000M, marioAccountIban);

            //BUY STOCK ASSET WITH MONEY
            unicredit.BuyStockAsset("Tesla", 1000, "Euro", marioAccountIban);

            //CENTRAL BANK NO SWIFT-------------------------------
            CentralBank russianCentralBank = new CentralBank("Central Bank of the the Russian Federation", "Mosca", "El'vira Nabiullina", "Russia");

            //COMMERCIAL BANK
            CommercialBank gazpromBank = new CommercialBank("Gazprombank", "Mosca", "Andrey Akimov", "Russia");
            russianCentralBank.AddCommercialBank(gazpromBank);

            //CLIENT
            bool ivanIsAdded = gazpromBank.AddBankClient("Ivan", "Smirnov", "IVNSMV22OI07U231", "11/09/1976", "maschio", "ivan.smirnov@gmail.com", "345563456", "Ulitsa Potylikha", "Mosca", "Russia");
            if (!ivanIsAdded) return;

            //BANK ACCOUNT
            gazpromBank.AddBankAccount("Ivan", "Smirnov", "IVNSMV22OI07U231");
            long ivanAccountIban = Test.Test.getIban(gazpromBank, "IVNSMV22OI07U231");

            //ASSET
            gazpromBank.AddFiatAsset("rublo", ivanAccountIban);
            gazpromBank.AddCryptoAsset("ETH", ivanAccountIban);

            //BANK TRANSFER-------------------------------------------
            unicredit.Transfer(intesaSanPaolo, new FIATTransferRequest { AssetName = "Euro", Amount = 878M, IBANFrom = marioAccountIban, IBANTo = ivanAccountIban });

            //unicredit.BankAccountProp.TransferFiat(998M, "IBAN");

            //gazpromBank.BankAccountProp.TransferFiat(1239M, "IBAN");

            //------------------------------------------------------------------------------------------------------------------
            //REMOVE
            bancaDItalia.RemoveCommercialBank(intesaSanPaolo);

            unicredit.RemoveBankClient("Nome", "Cognome", "SDFKHJ23987");
            unicredit.RemoveBankAccount(marioAccountIban);

            //REMOVE ASSET
            unicredit.RemoveFiatAsset("Euro", marioAccountIban);
            //unicredit.RemoveStockAsset("Tesla", marioAccountIban);
            unicredit.RemoveCryptoAsset("Bitcoin", marioAccountIban);
        }
    }
}
