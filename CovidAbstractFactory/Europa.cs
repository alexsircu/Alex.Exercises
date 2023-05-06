using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidAbstractFactory
{
    internal class Europa
    {
        static int _covidPositives;

        public static int CovidPositives { get => _covidPositives; set => _covidPositives = value; }
    }
}
