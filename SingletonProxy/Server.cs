using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonProxy
{
    internal class Server
    {
        string _name;

        public string Name { get => _name; set => _name = value; }
    }
}
