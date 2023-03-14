using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mondo
{
    internal class Nazione
    {
        string _name;
        Regione _regione;

        public Nazione(string nazioneName) 
        {
            Name = nazioneName;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public Regione Regione { get { return _regione;} set { _regione = value; } }

        public void AddRegione(Regione regione)
        {
            Regione  = regione;
        }

        public void RemoveRegione(Regione regione)
        {
            Regione = null;
        }
    }
}
