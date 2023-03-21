using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodiceFiscale
{
    internal class Nazione
    {
        string _name;

        public string Name { get { return _name; } set { _name = value; } }

        public Nazione(string name)
        {
            this.Name = name;
        }
    } 
}
