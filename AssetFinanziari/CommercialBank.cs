using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetFinanziari
{
    public class CommercialBank : Bank
    {
        BankClient _bankClient;
        BankAccount _bankAccount;
        string _BICNumber;

        public BankClient BankClient { get { return _bankClient; } set { _bankClient = value; } } 
        public BankAccount BankAccount { get { return _bankAccount ; } set { _bankAccount = value;} }
        public string BICNumber { get { return _BICNumber; } set { _BICNumber = value; } }

        public CommercialBank(string name, string headquarter, string ceo, string country) : base(name, headquarter, ceo, country)
        {
           
        }

        //ADD
        public void AddBankClient(string name, string surname, int age, string sex, string email, string phone, string homeAddress, string city, string country)
        {
            BankClient bankClient = new BankClient(name, surname, age, sex, email, phone, homeAddress, city, country, this);
            BankClient = bankClient;
        }

        public BankAccount AddBankAccount(BankClient bankClient)
        {
            BankAccount bankAccount = new BankAccount(this, bankClient);
            BankAccount = bankAccount;
            return BankAccount;
        } 

        //FIAT TRANSFER
        public void TransferFiat(BankAccount bankAccount, decimal amount)
        {
            if (bankAccount.CommercialBank.Country == Country)
            {
                bankAccount.DepositFiat(amount);
            } 
            else if (bankAccount.CommercialBank.BICNumber != null)
            {
                bankAccount.DepositFiat(amount);    
            } 
            else
            {
                Console.WriteLine("Non è possibile effettuare un bonifico al conto selezionato perchè il paese di origine è sanzionato");
                BankAccount.DepositFiat(amount);
            }
        }
    }
}