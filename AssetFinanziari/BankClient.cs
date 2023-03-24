using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetFinanziari
{
    public class BankClient : Person
    {
        string _phone;
        string _email;
        string _homeAddress;
        string _city;
        string _country;
        CommercialBank _commercialBank;
        BankAccount _bankAccount;

        public string Phone { get { return _phone; } set { _phone = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string HomeAddress { get { return _homeAddress; } set { _homeAddress = value; } }
        public string City { get { return _city; } set { _city = value; } }
        public string Country { get { return _country; } set { _country = value; } }
        public CommercialBank CommercialBank { get { return _commercialBank; } set { _commercialBank = value; } }
        public BankAccount BankAccount { get { return _bankAccount; } set { _bankAccount = value; } }

        public BankClient(string name, string surname, int age, string sex, string email, string phone, string homeAddress, string city, string country, CommercialBank commercialBank)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Sex = sex;
            Email = email;
            Phone = phone;
            HomeAddress = homeAddress;
            City = city;
            Country = country;
            CommercialBank = commercialBank;
        }

        //ADD
        public void AddBankAccount()
        {
            BankAccount = CommercialBank.AddBankAccount(this);
        }

        //HOW TO HANDLE REMOVE?
    }
}