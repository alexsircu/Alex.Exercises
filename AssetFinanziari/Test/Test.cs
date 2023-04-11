using AssetFinanziari.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AssetFinanziari.CommercialBank.BankAccount;

namespace AssetFinanziari.Test
{
    internal static class Test
    {
        public static long getIban(CommercialBank commercialBank, string cf)
        {
            var client = Array.Find(commercialBank.BankClientProp, client => client.ID == cf);
            return client.BankAccount[0].IBAN;
        }

        public static long getBankCode(Bank bank)
        {
            return bank.Code;
        }
    }
}
