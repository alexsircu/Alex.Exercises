using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce
{
    internal class Italia : PaeseEuropeo, IUE, IONU, ICorteEuropeaDirittiUmani
    {
        string _name;
        public string Name { get { return _name; } set { _name = value; } }
        public Italia(string name)
        {
            Name = name;
            CheckHumanRightsAgreement();
            ApplyCostitution();
            SviluppaRelazioniAmichevoli();
        }
        public override void PaeseContinenteEuropeo()
        {
            Console.WriteLine("Paese continente europeo");
        }
        public void CheckHumanRightsAgreement()
        {
            Console.WriteLine($"Il paese {Name} non rispetta diritti umani");
        }
        public void ApplyCostitution()
        {
            Console.WriteLine("Hai applicato le nostre regole");
        }
        public void SviluppaRelazioniAmichevoli()
        {
            Console.WriteLine($"Il paese {Name} è amichevole");
        }
    }
}
