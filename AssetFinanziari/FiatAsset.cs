using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetFinanziari
{
    public class FiatAsset : Asset
    {
        public FiatAsset(string name) : base(name)
        {
            
        }

        //OPERATIONS
        public bool WithdrawFiat(decimal fiatAmount)
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

        public void DepositFiat(decimal fiatAmount)
        {
            Amount += fiatAmount;
            Console.WriteLine($"Sono stati depositati {fiatAmount} euro. Saldo contabile: {Amount}");
        }
    }
}