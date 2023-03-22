using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interfacce
{
    internal class Vaticano : PaeseEuropeo, ICorteEuropeaDirittiUmani
    {
        string _name;
        public string Name { get { return _name; } set { _name = value; } }
        public Vaticano(string name)
        {
            Name = name;
            CheckHumanRightsAgreement();
        }
        public void CheckHumanRightsAgreement()
        {
            Console.WriteLine($"Il paese {Name} rispetta diritti umani");
        }
    }
}
