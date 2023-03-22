using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interfacce
{
    internal class Brasile : IONU
    {
        string _name;
        public string Name { get { return _name; } set { _name = value; } }
        public Brasile(string name)
        {
            Name = name;
            SviluppaRelazioniAmichevoli();
        }
        public void SviluppaRelazioniAmichevoli()
        {
            Console.WriteLine($"Il paese {Name} è molto amichevole");
        }
    }
}
