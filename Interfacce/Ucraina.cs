using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce
{
    internal class Ucraina : PaeseEuropeo, IONU, ICorteEuropeaDirittiUmani
    {
        string _name;
        public string Name { get { return _name; } set { _name = value; } }
        public Ucraina(string name)
        {
            Name = name;
            CheckHumanRightsAgreement();
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
        public void SviluppaRelazioniAmichevoli()
        {
            Console.WriteLine($"Il paese {Name} vorrebbe essere amichevole ma non può");
        }
    }
}
