using System;

namespace CodiceFiscale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRevenueAgency italia = new  Italia("Italia");
            IRevenueAgency germania = new Germania("Germania");

            Cittadino mario = new Cittadino("Mario", "Rossi");

            italia.CalcolaCodiceFiscale(mario);
            germania.CalcolaCodiceFiscale(mario);
        }
    }
}
