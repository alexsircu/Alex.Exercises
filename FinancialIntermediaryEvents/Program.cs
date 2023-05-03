using System;
using static FinancialIntermediaryEvents.CentralBank;

namespace FinancialIntermediaryEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommercialBank unicredit = new CommercialBank("Unicredit", "Andrea" ,"Orcel");
            StockMarket borsaItaliana = new StockMarket("Borsa Italiana", "Raffaele", "Jerusalmi");
            CryptoExchange youngPlatform = new CryptoExchange("Young Platform", "Andrea", "Ferrero");

            CentralBank bancaCentraleItaliana = new CentralBank("Banca d'Italia", "Ignazio", "Visco");
            bancaCentraleItaliana.ChangedCEO += new ChangeCEOEventHandler(unicredit.NotifyCentralBankCEOChanged);
            bancaCentraleItaliana.ChangedCEO += new ChangeCEOEventHandler(borsaItaliana.NotifyCentralBankCEOChanged);

            bancaCentraleItaliana.ChangeCEO("Mario", "Rossi");
        }
    }
}
