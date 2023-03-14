using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mondo
{
    internal class Regione
    {
        string _name;
        Nazione _nazione;
        Provincia _provincia;
        public Regione(string nameRegione, Nazione nazione) 
        {
            Name = nameRegione;
            Nazione = nazione;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public Provincia Provincia { get { return _provincia; } set { _provincia = value; } }
        public Nazione Nazione { get { return _nazione; } set { _nazione = value; } }

        public void AddProvincia(Provincia provincia)
        {
            Provincia = provincia;
        }

        public void RemoveProvincia(Provincia provincia)
        {
            Provincia = null;
        }
    }
}
