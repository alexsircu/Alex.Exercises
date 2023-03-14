using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mondo
{
    internal class ONU : Organizzazione
    {
        int _numeroCaschiBlu;

        public int NumeroCaschiBlu { get {  return _numeroCaschiBlu; } }

        public void AiutiUmanitari()
        {
            //invia aiuti umanitari
        }
    }
}
