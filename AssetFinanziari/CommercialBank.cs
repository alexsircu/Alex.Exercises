using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using AssetFinanziari.Abstract;
using AssetFinanziari.Model;
using AssetFinanziari.Static;

namespace AssetFinanziari
{
    internal class CommercialBank : Bank
    {
        BankClient[] _bankClient;
        BankAccount[] _bankAccount;
        CentralBank _centralBank;
        StockMarket _stockMarket;

        public BankClient[] BankClientProp { get { return _bankClient; } set { _bankClient = value; } } 
        public BankAccount[] BankAccountProp { get { return _bankAccount ; } set { _bankAccount = value;} }
        public CentralBank CentralBank { get { return _centralBank; } set { _centralBank = value; } }
        public StockMarket StockMarket { get { return _stockMarket; } set { _stockMarket = value; } }   

        public CommercialBank(string name, string headquarter, string ceo, string country) : base(name, headquarter, ceo, country)
        {
            BankClientProp = new BankClient[0];
            BankAccountProp = new BankAccount[0];
        }

        //TODO: edit cultureinfo by culture of the country and date format
        //ADD
        public bool AddBankClient(string name, string surname, string id, string birthday, string sex, string email, string phone, string homeAddress, string city, string country)
        {
            DateTime clientBirthday;
            CultureInfo culture = CultureInfo.CurrentCulture;
            string dateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

            if (DateTime.TryParseExact(birthday, dateFormat, culture, DateTimeStyles.None, out clientBirthday))
            {
                bool isAdult = IsAdult(clientBirthday);
                if (!isAdult) return false;

                BankClient bankClient = new BankClient(name, surname, id, clientBirthday, sex, email, phone, homeAddress, city, country, this);

                BankClient[] temporaryArray = new BankClient[BankClientProp.Length + 1];
                Array.Copy(BankClientProp, temporaryArray, BankClientProp.Length);
                BankClientProp = temporaryArray;
                BankClientProp[BankClientProp.Length - 1] = bankClient;
                return true;
            }

            Console.WriteLine("Date format is wrong");
            return false;
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

        public void AddStockMarket(StockMarket stockMarket)
        {
            if (Country != stockMarket.Country) return; 
            StockMarket = stockMarket;
        }

        //ADD ASSET
        public void AddFiatAsset(string fiatAsset, long accountIban)
        {
            BankAccount bankAccount = Array.Find(BankAccountProp, item => item.IBAN == accountIban);
            if (bankAccount is null) return;
            bankAccount.AddFiatAsset(fiatAsset);
        }

        public void AddCryptoAsset(string cryptoAsset, long accountIban)
        {
            BankAccount bankAccount = Array.Find(BankAccountProp, item => item.IBAN == accountIban);
            if (bankAccount is null) return;
            bankAccount.AddCryptoAsset(cryptoAsset);
        }

        //BUY STOCK
        public void BuyStockAsset(string assetName, decimal amount, string fiatAsset, long accountIban)
        {
            bool isOpen = IsOpenStockMarket(StockMarket);
            if (!isOpen) return;

            BankAccount bankAccount = Array.Find(BankAccountProp, item => item.IBAN == accountIban);
            if (bankAccount is null) return;

            bool isDone = bankAccount.WithdrawFiat(fiatAsset, amount);

            if (isDone) 
            {
                Asset stockAsset = base.BuyAsset(assetName, amount, StockMarket);
                if (stockAsset is null)
                {
                    CustomLog.WriteLog(CustomLog.Dir, CustomLog.FileName, new string[] { $"Time: {DateTime.Now.ToString("HH:mm:ss:fff")}, ", "Operation: buy stock denied stock not found, ", $"Bank: {Name}, ", $"Name: {bankAccount.BankClient.Name}, ", $"Surname: {bankAccount.BankClient.Surname}, ", $"Iban: {bankAccount.IBAN}, ", $"{fiatAsset} amount: {amount}" });
                    return;
                }
 
                bankAccount.AddStockAsset(stockAsset);
                CustomLog.WriteLog(CustomLog.Dir, CustomLog.FileName, new string[] { $"Time: {DateTime.Now.ToString("HH:mm:ss:fff")}, ", "Operation: buy stock accepted, ", $"Bank: {Name}, ", $"Name: {bankAccount.BankClient.Name}, ", $"Surname: {bankAccount.BankClient.Surname}, ", $"Iban: {bankAccount.IBAN}, ", $"{fiatAsset} amount: {amount}" });
            } 
            else
            {
                CustomLog.WriteLog(CustomLog.Dir, CustomLog.FileName, new string[] { $"Time: {DateTime.Now.ToString("HH:mm:ss:fff")}, ", "Operation: buy stock denied, ", $"Bank: {Name}, ", $"Name: {bankAccount.BankClient.Name}, ", $"Surname: {bankAccount.BankClient.Surname}, ", $"Iban: {bankAccount.IBAN}, ", $"{fiatAsset} amount: {amount}" });
            }
        }

        //ASSET OPERATIONS
        public override bool Transfer(CommercialBank to, FIATTransferRequest data)
        {
            BankAccount bankAccount = Array.Find(BankAccountProp, account => account.IBAN == data.IBANFrom);
            if (bankAccount is null) return false;

            //CHECK IF IMPLEMENTS SWIFT SYSTEM
            if (CentralBank.CheckTransfer(this, to, data))
            {
                bool result = bankAccount.WithdrawFiat(data.AssetName, data.Amount);

                if (result)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"The  amount {data.Amount} from the account {data.IBANFrom} from the Bank {Name} to " +
                        $"account {data.IBANTo} of from the Bank {to.Name} has been made! ");
                    Console.ResetColor();

                    CustomLog.WriteLog(CustomLog.Dir, CustomLog.FileName, new string[] { $"Time: {DateTime.Now.ToString("HH:mm:ss:fff")}, ", "Operation: transfer money completed, ", $"Bank: {Name}, ", $"Name: {bankAccount.BankClient.Name}, ", $"Surname: {bankAccount.BankClient.Surname}, ", $"Iban from: {data.IBANFrom}, ", $"Iban to: {data.IBANTo}, ", $"{data.AssetName} amount: {data.Amount}" });

                    return true;
                } 
                else
                {
                    CustomLog.WriteLog(CustomLog.Dir, CustomLog.FileName, new string[] { $"Time: {DateTime.Now.ToString("HH:mm:ss:fff")}, ", "Operation: transfer money denied, insufficient funds, ", $"Bank: {Name}, ", $"Name: {bankAccount.BankClient.Name}, ", $"Surname: {bankAccount.BankClient.Surname}, ", $"Iban from: {data.IBANFrom}, ", $"Iban to: {data.IBANTo}, ", $"{data.AssetName} amount: {data.Amount}" });
                }
            }
            CustomLog.WriteLog(CustomLog.Dir, CustomLog.FileName, new string[] { $"Time: {DateTime.Now.ToString("HH:mm:ss:fff")}, ", "Operation: transfer money denied, ", $"Bank: {Name}, ", $"Name: {bankAccount.BankClient.Name}, ", $"Surname: {bankAccount.BankClient.Surname}, ", $"Iban from: {data.IBANFrom}, ", $"Iban to: {data.IBANTo}, ", $"{data.AssetName} amount: {data.Amount}" });
            return false;
        }

        public void DepositFiat(string fiatName, decimal amount, long accountIban)
        {
            BankAccount bankAccount = Array.Find(BankAccountProp, item => item.IBAN == accountIban);
            if (bankAccount is null) return;

            bankAccount.DepositFiat(fiatName, amount);
        }

        public void WithdrawFiat(string fiatName, decimal fiatAmount, long accountIban)
        {
            BankAccount bankAccount = Array.Find(BankAccountProp, item => item.IBAN == accountIban);
            if (bankAccount is null) return;

            bankAccount.WithdrawFiat(fiatName, fiatAmount);
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

        public void RemoveCryptoAsset(string cryptoAsset, long iban)
        {
            BankAccount account = Array.Find(BankAccountProp, account => account.IBAN == iban);
            if (account is null) return;
            account.RemoveCryptoAsset(cryptoAsset);
        }

        //TODO: Method refactor to SellStockAsset
        /*public void RemoveStockAsset(string stockAsset, long iban)
        {
            BankAccount account = Array.Find(BankAccountProp, account => account.IBAN == iban);
            if (account is null) return;
            account.RemoveStockAsset(stockAsset);
        }*/

        //WORKING HOURS
        public bool IsOpenStockMarket(StockMarket stockMarket)
        {
            TimeSpan actualTime = DateTime.Now.TimeOfDay; 

            if (stockMarket.OpeningTime <= actualTime && stockMarket.ClosingTime >= actualTime)
            {
                Console.WriteLine($"{stockMarket.Name} is open");
                return true;
            }

            Console.WriteLine($"{StockMarket.Name} is closed");
            return false;
        }

        //IS ADULT
        private bool IsAdult(DateTime birthday)
        {
            if (birthday.AddYears(18) <= DateTime.Now) return true;

            Console.WriteLine("Is not adult");
            return false;
        }

        
        //BANKCLIENT-----------------------------------------------------------------------
        internal class BankClient : Person
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

            public BankClient(string name, string surname, string id, DateTime birthday, string sex, string email, string phone, string homeAddress, string city, string country, CommercialBank commercialBank) : base(name, surname, id, birthday, sex)
            {
                Birthday = birthday;
                Email = email;
                Phone = phone;
                HomeAddress = homeAddress;
                City = city;
                Country = country;
                CommercialBank = commercialBank;

                BankAccount = new BankAccount[0];
            }

            public void AddBankAccount(BankAccount bankAccount)
            {
                BankAccount[] temporaryArray = new BankAccount[BankAccount.Length + 1];
                Array.Copy(BankAccount, temporaryArray, BankAccount.Length);
                BankAccount = temporaryArray;
                BankAccount[BankAccount.Length - 1] = bankAccount;
            }
        }

        //BANKACCOUNT----------------------------------------------------------------------
        internal class BankAccount
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

            //ADD ASSET
            public void AddFiatAsset(string fiatAsset)
            {
                FiatAsset fiat = new FiatAsset(fiatAsset);

                Asset[] temporaryArray = new Asset[Asset.Length + 1];
                Array.Copy(Asset, temporaryArray, Asset.Length);
                Asset = temporaryArray;
                Asset[Asset.Length - 1] = fiat;
            }

            public void AddStockAsset(Asset stockAsset)
            {
                Asset[] temporaryArray = new Asset[Asset.Length + 1];
                Array.Copy(Asset, temporaryArray, Asset.Length);
                Asset = temporaryArray;
                Asset[Asset.Length - 1] = stockAsset;

                Console.WriteLine($"Nuova stock aggiunta al conto con numero {IBAN} di {BankClient.Name}. Comprate {stockAsset.Name}");
            }

            public void AddCryptoAsset(string cryptoAsset)
            {
                CryptoAsset crypto = new CryptoAsset(cryptoAsset);

                Asset[] temporaryArray = new Asset[Asset.Length + 1];
                Array.Copy(Asset, temporaryArray, Asset.Length);
                Asset = temporaryArray;
                Asset[Asset.Length - 1] = crypto;
            }

            //REMOVE ASSET
            public void RemoveFiatAsset(string fiatAsset)
            {
                Asset[] array = Asset.Where(asset => asset.Name != fiatAsset).ToArray();
                Asset = array;
            }

            //TODO: Method refactor remove stockAsset by StockAsset obj and add fiat to FiatAsset
            /*public void RemoveStockAsset(string stockAsset)
            {
                var array = Asset.Where(asset => asset.Name != stockAsset).ToArray();
                Asset = array;
            }*/

            public void RemoveCryptoAsset(string cryptoAsset)
            {
                Asset[] array = Asset.Where(asset => asset.Name != cryptoAsset).ToArray();
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
            public void DepositFiat(string fiatName, decimal fiatAmount)
            {
                Asset asset = Array.Find(Asset, asset => asset.Name == fiatName);
                if (asset is null) return;

                asset.Deposit(fiatAmount);
            }

            //FIATASSET CLASS------------------------------------------------------
            internal class FiatAsset : Asset
            {
                bool _isDailyLimitExceed;
                decimal _dailyAmountWithdraw;
                int _dailyLimit;
                DateTime _lastWithdraw;
                bool _isMonthlyLimitExceed;
                decimal _monthlyAmountWithdraw;
                int _monthlyLimit;
                DateTime _dayAccountBlocked;
                bool _isAccountBlocked;

                public bool IsDailyLimitExceed { get { return _isDailyLimitExceed; } set { _isDailyLimitExceed = value; } }
                public decimal DailyAmountWithdraw { get { return _dailyAmountWithdraw; } set { _dailyAmountWithdraw = value; } }
                public int DailyLimit { get { return _dailyLimit; } set { _dailyLimit = value; } }
                public DateTime LastWithdraw { get { return _lastWithdraw; } set { _lastWithdraw = value; } }
                public bool IsMonthlyLimitExceed { get { return _isMonthlyLimitExceed; } set { _isMonthlyLimitExceed = value; } }
                public decimal MonthlyAmountWithdraw { get { return _monthlyAmountWithdraw; } set { _monthlyAmountWithdraw = value; } }
                public int MonthlyLimit { get { return _monthlyLimit; } set { _monthlyLimit = value; } }
                public DateTime DayAccountBlocked { get { return _dayAccountBlocked; } set { _dayAccountBlocked = value; } }
                public bool IsAccountBlocked { get { return _isAccountBlocked; } set { _isAccountBlocked = value; } }

                public FiatAsset(string name) : base(name)
                {
                    IsDailyLimitExceed = false;
                    IsMonthlyLimitExceed = false;
                    DailyLimit = 10000;
                }

                //TODO: Use new method instead of Withdraw when money are transfered
                //OPERATIONS
                public override bool Withdraw(decimal fiatAmount)
                {
                    CheckDayChange();
                    CheckMonthChange();
                    CheckLimitExceed(fiatAmount);
                    
                    if (IsMonthlyLimitExceed)
                    {
                        UnlockAccount();
                        return false;
                    }

                    if (IsAccountBlocked) 
                    {
                        Console.WriteLine($"Your account is blocke until {DayAccountBlocked}");
                        return false; 
                    }

                    if (IsDailyLimitExceed) 
                    {
                        Console.WriteLine("Exceeded the limit of money you can withdraw");
                        return false;
                    }

                    bool isEnough = CheckCredit(fiatAmount);

                    if (!isEnough)
                    {
                        Console.WriteLine("Non ci sono fondi sufficienti per effettuare questa operazione");
                        return false;
                    }
                    else 
                    {
                        Amount -= fiatAmount;
                        DailyAmountWithdraw += fiatAmount;
                        MonthlyAmountWithdraw += fiatAmount;
                        LastWithdraw = DateTime.Now;

                        Console.WriteLine($"Sono stati prelevati {fiatAmount} euro. Saldo contabile: {Amount}");
                        return true;
                    }
                }

                public override void Deposit(decimal fiatAmount)
                {
                    Amount += fiatAmount;
                    Console.WriteLine($"Sono stati depositati {fiatAmount} euro. Saldo contabile: {Amount}");
                    //CustomLog.WriteLog(CustomLog.Dir, CustomLog.FileName, new string[] { $"Time: {DateTime.Now.ToString("HH:mm:ss")}, ", "Operation: deposit money accepted, ", $"Bank: {Name}, ", $"Name: {bankAccount.BankClient.Name}, ", $"Surname: {bankAccount.BankClient.Surname}, ", $"Iban from: {data.IBANFrom}, ", $"Iban to: {data.IBANTo}, ", $"{data.AssetName} amount: {data.Amount}" });
                }

                private void CheckDayChange()
                {
                    if (LastWithdraw.Day != DateTime.Now.Day) 
                    {
                        DailyAmountWithdraw = 0;
                        IsDailyLimitExceed = false;
                    }
                }

                private void CheckMonthChange()
                {
                    if (LastWithdraw.Month != DateTime.Now.Month)
                    {
                        MonthlyAmountWithdraw = 0;
                        IsMonthlyLimitExceed = false;
                        IsAccountBlocked = false;
                    }
                }

                private void UnlockAccount()
                {
                    if (DateTime.Now > DayAccountBlocked) 
                    {
                        IsAccountBlocked = false;
                    } 
                }

                private void CheckLimitExceed(decimal fiatAmount)
                {
                    decimal dailyTot = DailyAmountWithdraw + fiatAmount;
                    if (dailyTot > DailyLimit) IsDailyLimitExceed = true;

                    decimal monthlyTot = MonthlyAmountWithdraw + fiatAmount;
                    if (monthlyTot > MonthlyLimit && MonthlyAmountWithdraw < MonthlyLimit)
                    {
                        DayAccountBlocked = DateTime.Now.AddDays(3);
                        IsAccountBlocked = true;
                        IsMonthlyLimitExceed = true;
                    }  
                }

                private bool CheckCredit(decimal fiatAmount)
                {
                    if (Amount <= 0 || fiatAmount > Amount) return false;
                    return true;
                }
            }

            //CRYPTOASSET----------------------------------------------------------
            internal class CryptoAsset : Asset
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