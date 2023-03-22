using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce
{
    internal class Bielorussia : PaeseEuropeo, IONU, IPenaDiMorte, ICorteEuropeaDirittiUmani
    {
        string _name;
        public string Name { get { return _name; } set { _name = value; } }
        public Bielorussia(string name)
        {
            Name = name;
            ApplicaPenaMorte();
            CheckHumanRightsAgreement();
            SviluppaRelazioniAmichevoli();
        }
        public void ApplicaPenaMorte()
        {
            Console.WriteLine($"Il paese {Name} applica la pena di morte");
        }
        public void CheckHumanRightsAgreement()
        {
            Console.WriteLine($"Il paese {Name} non rispetta diritti umani");
        }
        public void SviluppaRelazioniAmichevoli()
        {
            Console.WriteLine($"Il paese {Name} non è molto amichevole");
        }
    }
}
