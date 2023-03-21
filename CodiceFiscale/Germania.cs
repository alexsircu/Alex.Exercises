using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodiceFiscale
{
    internal class Germania : Nazione, IRevenueAgency
    {
        public Germania(string name) : base(name)
        {

        }
        void IRevenueAgency.CalcolaCodiceFiscale(Cittadino cittadino)
        {
            string cf = cittadino.Surname + " " + cittadino.Name;
            Console.WriteLine($"La nazione {Name} calcola il codice fiscale di {cittadino.Name}: {cf}");
        }
    }
}
