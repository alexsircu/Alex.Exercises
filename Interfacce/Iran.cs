using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce
{
    internal class Iran : IONU, IPenaDiMorte
    {
        string _name;
        public string Name { get { return _name; } set { _name = value; } }
        public Iran(string name)
        {
            Name = name;
            ApplicaPenaMorte();
            SviluppaRelazioniAmichevoli();
        }
        public void ApplicaPenaMorte()
        {
            Console.WriteLine($"Il paese {Name} applica la pena di morte");
        }
        public void SviluppaRelazioniAmichevoli()
        {
            Console.WriteLine($"Il paese {Name} non è molto amichevole");
        }
    }
}
