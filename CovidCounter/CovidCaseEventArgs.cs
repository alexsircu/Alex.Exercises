using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidCounter
{
    internal class CovidCaseEventArgs : EventArgs
    {
        int _newCovidCase;
        public bool cancel;

        public int NewCovidCase { get => _newCovidCase; }

        public CovidCaseEventArgs(int value) 
        {
            this._newCovidCase = value;
        }
    }
}
