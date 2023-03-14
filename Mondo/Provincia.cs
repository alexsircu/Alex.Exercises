using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mondo
{
    internal class Provincia
    {
        string _name;
        Comune _comune;
        Regione _regione;

        public Provincia(string provinciaName, Regione regione)
        {
            Name = provinciaName;
            Regione = regione;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public Comune Comune { get { return _comune; } set { _comune = value; } }
        public Regione Regione { get { return _regione;} set { _regione = value; } }

        public void AddComune(Comune comune)
        {
            Comune = comune;
        }

        public void RemoveComune(Comune comune)
        {
            Comune = null;
        }
    }
}
