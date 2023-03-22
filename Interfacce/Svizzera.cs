using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce
{
    internal class Svizzera : PaeseEuropeo, IONU, ICorteEuropeaDirittiUmani
    {
        string _name;
        public string Name { get { return _name; } set { _name = value; } }
        public Svizzera(string name)
        {
            Name = name;
            CheckHumanRightsAgreement();
            SviluppaRelazioniAmichevoli();
        }
        public void CheckHumanRightsAgreement()
        {
            Console.WriteLine($"Il paese {Name} rispetta diritti umani");
        }
        public void SviluppaRelazioniAmichevoli()
        {
            Console.WriteLine($"Il paese {Name} si fa gli affari suoi");
        }
    }
}
