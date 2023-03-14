using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mondo
{
    internal class Abitante
    {
        string _name;
        string _cognome;
        Comune _comune;

        public Abitante(string nameAbitante, Comune comune)
        {
            Name = nameAbitante;
            Comune = comune;
        }

        public string Name { get { return _name;} set { _name = value; } }
        public string Cognome { get { return _cognome; } set => _cognome = value; }
        public Comune Comune { get { return _comune;} set { _comune = value; } }
        
    }
}
