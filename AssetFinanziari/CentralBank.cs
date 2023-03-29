using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssetFinanziari.Abstract;
using AssetFinanziari.Model;
using AssetFinanziari.Static;

namespace AssetFinanziari
{
    public class CentralBank : Bank
    {
        CommercialBank[] _commercialBank;

        public CommercialBank[] CommercialBank { get { return _commercialBank; } set { _commercialBank = value; } }

        public CentralBank(string name, string headquarter, string ceo, string country) : base(name, headquarter, ceo, country)
        {
            CommercialBank = new CommercialBank[0];
        }

        //ADD
        public void AddCommercialBank(CommercialBank commercialBank)
        {
            CommercialBank[] temporaryArray = new CommercialBank[CommercialBank.Length + 1];
            Array.Copy(CommercialBank, temporaryArray, CommercialBank.Length);
            CommercialBank = temporaryArray;
            CommercialBank[CommercialBank.Length - 1] = commercialBank;

            commercialBank.AddCentralBank(this);
        }

        //REMOVE
        public void RemoveCommercialBank(CommercialBank commercialBank)
        {
            var array = CommercialBank.Where(bank => bank.Code != commercialBank.Code).ToArray();
            CommercialBank = array;
        }

        //TRANSFER
        public bool CheckTransfer(CommercialBank from, CommercialBank to, FIATTransferRequest data)
        {
            if (from.Country == to.Country)
            {
                return true;
            }
            else
            {
                if (WorldBank.Transfer(from, to))
                {
                    return true;
                }
                return false;
            }
        }
    }
}