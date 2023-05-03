using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialIntermediaryEvents.Delegates;

namespace FinancialIntermediaryEvents
{
    internal class StockMarket : CentralBank
    {
        public StockMarket(string intermediaryName, string name, string surname) : base(intermediaryName, name, surname)
        {
        }

        public override void NotifyCentralBankCEOChanged(object sender, ChangeCEOEventArgs e)
        {
            Console.WriteLine($"Notificato all'ente {Name} che {e.Name} {e.Surname} è il nuovo CEO di {sender.GetType().GetProperty("Name").GetValue(sender)}");
        }
    }
}
