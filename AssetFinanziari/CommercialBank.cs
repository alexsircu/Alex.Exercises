using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using AssetFinanziari.Abstract;
using AssetFinanziari.Model;
using static AssetFinanziari.CommercialBank;
using static AssetFinanziari.CommercialBank.BankAccount;

namespace AssetFinanziari
{
    public class CommercialBank : Bank
    {
        BankClient[] _bankClient;
        BankAccount[] _bankAccount;
        CentralBank _centralBank;
        /*string _BICNumber;*/

        public BankClient[] BankClientProp { get { return _bankClient; } set { _bankClient = value; } } 
        public BankAccount[] BankAccountProp { get { return _bankAccount ; } set { _bankAccount = value;} }
        public CentralBank CentralBank { get { return _centralBank; } set { _centralBank = value; } }
        /*public string BICNumber { get { return _BICNumber; } set { _BICNumber = value; } }*/

        public CommercialBank(string name, string headquarter, string ceo, string country) : base(name, headquarter, ceo, country)
        {
            BankClientProp = new BankClient[0];
            BankAccountProp = new BankAccount[0];
        }

        //ADD
        public void AddBankClient(string name, string surname, string id, int age, string sex, string email, string phone, string homeAddress, string city, string country)
        {
            BankClient bankClient = new BankClient(name, surname, id, age, sex, email, phone, homeAddress, city, country, this);

            BankClient[] temporaryArray = new BankClient[BankClientProp.Length + 1];
            Array.Copy(BankClientProp, temporaryArray, BankClientProp.Length);
            BankClientProp = temporaryArray;
            BankClientProp[BankClientProp.Length - 1] = bankClient;
        }

        public void AddBankAccount(string name, string surname, string id)
        {
            BankClient bankClient = Array.Find(BankClientProp, client => client.ID.Equals(id) && client.Name.Equals(name) && client.Surname.Equals(surname)); 
            
            BankAccount bankAccount = new BankAccount(this, bankClient);

            bankClient.AddBankAccount(bankAccount);

            BankAccount[] temporaryArray = new BankAccount[BankAccountProp.Length + 1];
            Array.Copy(BankAccountProp, temporaryArray, BankAccountProp.Length);
            BankAccountProp = temporaryArray;
            BankAccountProp[BankAccountProp.Length - 1] = bankAccount;
        } 

        public void AddCentralBank(CentralBank centralBank)
        {
            CentralBank = centralBank;
        }

        //ADD ASSET
        public void AddFiatAsset(string fiatAsset, long accountIban)
        {
            BankAccount bankAccount = Array.Find(BankAccountProp, item => item.IBAN == accountIban);
            if (bankAccount is null) return;
            bankAccount.AddFiatAsset(fiatAsset);
        }

        public void AddStockAsset(string stockAsset, long accountIban)
        {
            BankAccount bankAccount = Array.Find(BankAccountProp, item => item.IBAN == accountIban);
            if (bankAccount is null) return;
            bankAccount.AddStockAsset(stockAsset);
        }

        public void AddCryptoAsset(string cryptoAsset, long accountIban)
        {
            BankAccount bankAccount = Array.Find(BankAccountProp, item => item.IBAN == accountIban);
            if (bankAccount is null) return;
            bankAccount.AddCryptoAsset(cryptoAsset);
        }

        //ASSET OPERATIONS
        public override bool Transfer(CommercialBank to, FIATTransferRequest data)
        {
            //CHECK IF IMPLEMENTS SWIFT SYSTEM
            if (CentralBank.CheckTransfer(this, to, data))
            {

                //find account
                BankAccount account = Array.Find(BankAccountProp, account => account.IBAN == data.IBANFrom);

                if (account is null) return false;

                bool result = account.WithdrawFiat(data.AssetName, data.Amount);

                if (result)
                {
                    // confronto le due cifr dopo il prelievo. 
                    /*Utility.GetAccountInfo(ConsoleColor.Red, this, false, data);

                    transferTo.account.DepositFIAT(data.Amount);
                    Utility.GetAccountInfo(ConsoleColor.Green, transferTo, true, data);*/


                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"The  amount {data.Amount} from the account {data.IBANFrom} from the Bank {Name} to " +
                        $"account {data.IBANTo} of from the Bank {to.Name} has been made! ");
                    Console.ResetColor();

                    return true;
                } 
                else
                {
                    Console.WriteLine("There are not sufficient founds");
                }
            }

            Console.WriteLine("Amount not transfered");
            return false;

        }

        public void DepositFiat(string fiatName, decimal amount, long accountIban)
        {
            BankAccount bankAccount = Array.Find(BankAccountProp, item => item.IBAN == accountIban);
            if (bankAccount is null) return;

            var asset = Array.Find(bankAccount.Asset, asset => asset.Name == fiatName);
            if (asset is null) return;

            asset.Deposit(amount);
        }

        //REMOVE
        public void RemoveBankClient(string name, string surname, string id)
        {
            BankClient client = Array.Find(BankClientProp, client => client.ID == id && client.Name == name && client.Surname == surname);
            if (client is null) return;
            Array.Clear(client.BankAccount, 0, client.BankAccount.Length);

            var array = BankClientProp.Where(client => client.ID != id && client.Name != name && client.Surname != surname).ToArray();
            BankClientProp = array;
        }

        public void RemoveBankAccount(long iban)
        {
            var array = BankAccountProp.Where(account => account.IBAN != iban).ToArray();
            BankAccountProp = array;
        }

        public void RemoveFiatAsset(string fiatAsset, long iban)
        {
            BankAccount account = Array.Find(BankAccountProp, account => account.IBAN == iban);
            if (account is null) return;
            account.RemoveFiatAsset(fiatAsset);
        }

        public void RemoveStockAsset(string stockAsset, long iban)
        {
            BankAccount account = Array.Find(BankAccountProp, account => account.IBAN == iban);
            if (account is null) return;
            account.RemoveStockAsset(stockAsset);
        }

        public void RemoveCryptoAsset(string cryptoAsset, long iban)
        {
            BankAccount account = Array.Find(BankAccountProp, account => account.IBAN == iban);
            if (account is null) return;
            account.RemoveCryptoAsset(cryptoAsset);
        }
        //BANKCLIENT
        public class BankClient : Person
        {
            string _phone;
            string _email;
            string _homeAddress;
            string _city;
            string _country;
            CommercialBank _commercialBank;
            BankAccount[] _bankAccount;

            public string Phone { get { return _phone; } set { _phone = value; } }
            public string Email { get { return _email; } set { _email = value; } }
            public string HomeAddress { get { return _homeAddress; } set { _homeAddress = value; } }
            public string City { get { return _city; } set { _city = value; } }
            public string Country { get { return _country; } set { _country = value; } }
            public CommercialBank CommercialBank { get { return _commercialBank; } set { _commercialBank = value; } }
            public BankAccount[] BankAccount { get { return _bankAccount; } set { _bankAccount = value; } }

            public BankClient(string name, string surname, string id, int age, string sex, string email, string phone, string homeAddress, string city, string country, CommercialBank commercialBank)
            {
                Name = name;
                Surname = surname;
                ID = id;
                Age = age;
                Sex = sex;
                Email = email;
                Phone = phone;
                HomeAddress = homeAddress;
                City = city;
                Country = country;

                AddCommercialBank(commercialBank);
                BankAccount = new BankAccount[0];
            }

            void AddCommercialBank(CommercialBank commercialBank)
            {
                CommercialBank = commercialBank;
            }

            public void AddBankAccount(BankAccount bankAccount)
            {
                BankAccount[] temporaryArray = new BankAccount[BankAccount.Length + 1];
                Array.Copy(BankAccount, temporaryArray, BankAccount.Length);
                BankAccount = temporaryArray;
                BankAccount[BankAccount.Length - 1] = bankAccount;
            }
        }

        //BANKACCOUNT
        public class BankAccount
        {
            public long _IBAN;
            CommercialBank _commercialBank;
            BankClient _bankClient;
            Asset[] _asset;

            public long IBAN { get { return _IBAN; } set { _IBAN = value; } }
            public CommercialBank CommercialBank { get { return _commercialBank; } set { _commercialBank = value; } }
            public BankClient BankClient { get { return _bankClient; } set { _bankClient = value; } }
            public Asset[] Asset { get { return _asset; } set { _asset = value; } }

            public BankAccount(CommercialBank commercialBank, BankClient bankClient)
            {
                CommercialBank = commercialBank;
                BankClient = bankClient;
                IBAN = new Random().Next(10000, 1000000);
                Asset = new Asset[0];
            }

            //ADD
            public void AddFiatAsset(string fiatAsset)
            {
                FiatAsset fiat = new FiatAsset(fiatAsset);

                Asset[] temporaryArray = new Asset[Asset.Length + 1];
                Array.Copy(Asset, temporaryArray, Asset.Length);
                Asset = temporaryArray;
                Asset[Asset.Length - 1] = fiat;
            }
            public void AddStockAsset(string stockAsset)
            {
                StockAsset stock = new StockAsset(stockAsset);

                Asset[] temporaryArray = new Asset[Asset.Length + 1];
                Array.Copy(Asset, temporaryArray, Asset.Length);
                Asset = temporaryArray;
                Asset[Asset.Length - 1] = stock;
            }
            public void AddCryptoAsset(string cryptoAsset)
            {
                StockAsset crypto = new StockAsset(cryptoAsset);

                Asset[] temporaryArray = new Asset[Asset.Length + 1];
                Array.Copy(Asset, temporaryArray, Asset.Length);
                Asset = temporaryArray;
                Asset[Asset.Length - 1] = crypto;
            }

            //REMOVE
            public void RemoveFiatAsset(string fiatAsset)
            {
                var array = Asset.Where(asset => asset.Name != fiatAsset).ToArray();
                Asset = array;
            }

            public void RemoveStockAsset(string stockAsset)
            {
                var array = Asset.Where(asset => asset.Name != stockAsset).ToArray();
                Asset = array;
            }

            public void RemoveCryptoAsset(string cryptoAsset)
            {
                var array = Asset.Where(asset => asset.Name != cryptoAsset).ToArray();
                Asset = array;
            }

            //FIAT OPERATIONS
            public bool WithdrawFiat(string assetName, decimal fiatAmount)
            {
                Asset asset = Array.Find(Asset, asset => asset.Name == assetName);
                if (asset is null) return false;
                bool result = asset.Withdraw(fiatAmount);

                if (result) return true;

                return false;
                
            }
            public void DepositFiat(decimal fiatAmount)
            {
                //FiatAssetProp.DepositFiat(fiatAmount);
            }

            //STOCK OPERATIONS
            public void BuyStock()
            {
                //StockAssetProp.BuyStock();
            }

            public void SellStock()
            {
                //StockAssetProp.SellStock();
            }


            //CRYPTO OPERATIONS
            public void BuyCrypto()
            {
                //CryptoAssetProp.BuyCrypto();
            }

            public void SellCrypto()
            {
                //CryptoAssetProp.SellCrypto();
            }

            //FIAT TRANSFER 
            /*public void TransferFiat(decimal amount, BankAccount bankAccount)
            {
                bool check = FiatAssetProp.WithdrawFiat(amount);
                if (check) CommercialBank.TransferFiat(bankAccount, amount);
                if (!check) Console.WriteLine("Non è possibile effettuale il bonifico. Fondi insufficienti");
            }*/

            //ASSETS CLASS
            public class FiatAsset : Asset
            {
                public FiatAsset(string name) : base(name)
                {

                }

                //OPERATIONS
                public override bool Withdraw(decimal fiatAmount)
                {
                    if (Amount <= 0 || fiatAmount > Amount)
                    {
                        Console.WriteLine("Non ci sono fondi sufficienti per effettuare questa operazione");
                        return false;
                    }
                    else
                    {
                        Amount -= fiatAmount;
                        Console.WriteLine($"Sono stati prelevati {fiatAmount} euro. Saldo contabile: {Amount}");
                        return true;
                    }
                }

                public override void Deposit(decimal fiatAmount)
                {
                    Amount += fiatAmount;
                    Console.WriteLine($"Sono stati depositati {fiatAmount} euro. Saldo contabile: {Amount}");
                }
            }

            public class StockAsset : Asset
            {
                public StockAsset(string name) : base(name)
                {

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

            public class CryptoAsset : Asset
            {
                public CryptoAsset(string name) : base(name)
                {

                }

                //OPERATIONS
                public void BuyCrypto()
                {
                    Console.WriteLine("Buy Bitcoin");
                }

                public void SellCrypto()
                {
                    Console.WriteLine("Sell Bitcoin");
                }
            }
        }
    }
}