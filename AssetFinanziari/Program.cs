using System;
using AssetFinanziari.Model;
using AssetFinanziari.Test;

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

            CommercialBank intesaSanPaolo = new CommercialBank("Intesa San Paolo", "Torino", "Andrea Orcel", "Italia");
            bancaDItalia.AddCommercialBank(intesaSanPaolo);

            //CLIENT
            unicredit.AddBankClient("Mario", "Rossi", "MRARSS13S08H501H", 43, "maschio", "mario.rossi@gmail.com", "3287655611", "Via Torino", "Milano", "Italia");

            //BANK ACCOUNT
            unicredit.AddBankAccount("Mario", "Rossi", "MRARSS13S08H501H");
            long marioAccountIban = Test.Test.getIban(unicredit, "MRARSS13S08H501H");

            //ASSET
            unicredit.AddFiatAsset("Euro", marioAccountIban);
            unicredit.AddFiatAsset("GBP", marioAccountIban);
            unicredit.AddStockAsset("Tesla", marioAccountIban);
            unicredit.AddCryptoAsset("Bitcoin", marioAccountIban);
          
            //FIAT OPERATIONS
            unicredit.DepositFiat("Euro", 3700M, marioAccountIban);
            unicredit.DepositFiat("GBP", 12000M, marioAccountIban);
            //unicredit.BankAccountProp.WithdrawFiat(120M);

            //STOCK OPERATIONS
            //unicredit.BankAccountProp.BuyStock();
            //unicredit.BankAccountProp.SellStock();

            //CRYPTO OPERATIONS
            //unicredit.BankAccountProp.BuyCrypto();
            //unicredit.BankAccountProp.SellCrypto();

            //CENTRAL BANK NO SWIFT-------------------------------
            CentralBank russianCentralBank = new CentralBank("Central Bank of the the Russian Federation", "Mosca", "El'vira Nabiullina", "Russia");

            //COMMERCIAL BANK
            CommercialBank gazpromBank = new CommercialBank("Gazprombank", "Mosca", "Andrey Akimov", "Russia");
            russianCentralBank.AddCommercialBank(gazpromBank);

            //CLIENT
            gazpromBank.AddBankClient("Ivan", "Smirnov", "IVNSMV22OI07U231", 34, "maschio", "ivan.smirnov@gmail.com", "345563456", "Ulitsa Potylikha", "Mosca", "Russia");

            //BANK ACCOUNT
            gazpromBank.AddBankAccount("Ivan", "Smirnov", "IVNSMV22OI07U231");
            long ivanAccountIban = Test.Test.getIban(gazpromBank, "IVNSMV22OI07U231");

            //ASSET
            gazpromBank.AddFiatAsset("rublo", ivanAccountIban);
            gazpromBank.AddStockAsset("Lukoil", ivanAccountIban);
            gazpromBank.AddCryptoAsset("ETH", ivanAccountIban);

            //BANK TRANSFER--------------------------

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
            unicredit.RemoveStockAsset("Tesla", marioAccountIban);
            unicredit.RemoveCryptoAsset("Bitcoin", marioAccountIban);
        }
    }
}
