using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mondo
{
    internal class Organizzazione
    {
        string _name;
        string _sede;
        string _presidente;
        int _numeroDipendenti;
        //Nazione _nazione;

        public string Name { get { return _name; } set { _name = value; } }
        public string Sede { get { return _sede; } set { _sede = value; } }
        public string Presidente { get { return _presidente; } set { _presidente = value; } }
        public int NumeroDipendenti { get { return _numeroDipendenti; } set { _numeroDipendenti = value; } }
        //public Nazione Nazione { get { return _nazione; } set { _nazione = value; } }    

        /*public void AddNazione(Nazione nazione)
        {
            Nazione = nazione;
        }

        public void RemoveNazione(Nazione nazione)
        {
            Nazione = null;
        }*/

        public void InvocaLegge()
        {
            //invocare legge
        }

        public void Sanziona()
        {
            //sanziona
        }

    }
}
