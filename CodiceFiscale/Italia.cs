using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodiceFiscale
{
    internal class Italia : Nazione, IRevenueAgency
    {
        public Italia(string name) : base(name)
        {

        }
        void IRevenueAgency.CalcolaCodiceFiscale(Cittadino cittadino)
        {
            string cf = cittadino.Name + " " + cittadino.Surname;
            Console.WriteLine($"La nazione {Name} calcola il codice fiscale di {cittadino.Name}: {cf}");
        }
    }
}
