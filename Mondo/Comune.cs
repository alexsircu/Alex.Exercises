using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mondo
{
    internal class Comune
    {
        string _name;
        Abitante _abitante;
        Provincia _provincia;

        public Comune(string comuneName, Provincia provincia)
        {
            Name = comuneName;
            Provincia = provincia;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public Abitante Abitante { get { return _abitante; } set { _abitante = value; } }
        public Provincia Provincia { get { return _provincia; } set { _provincia = value; } }

        public void AddAbitante(Abitante abitante)
        {
            Abitante = abitante;
        }

        public void RemoveAbitante(Abitante abitante)
        {
            Abitante = null;
        }
    }
}
