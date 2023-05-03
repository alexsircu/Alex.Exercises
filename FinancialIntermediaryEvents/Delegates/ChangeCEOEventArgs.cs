using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialIntermediaryEvents.Delegates
{
    internal class ChangeCEOEventArgs : EventArgs
    {
        string _name;
        string _surname;

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }

        public ChangeCEOEventArgs(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }
    }
}
