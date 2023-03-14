using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mondo
{
    internal class Continente : AreaGeografica
    {
        Nazione _nazione; 
        public Continente(string nazioneName) 
        { 
            Nazione = new Nazione(nazioneName);
        }

        public Nazione Nazione { get { return _nazione; } set { _nazione = value; } }
    }
}
