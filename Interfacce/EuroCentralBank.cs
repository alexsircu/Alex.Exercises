using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce
{
    internal class EuroCentralBank
    {
        public void CalcolaSpread(IUE nazione) 
        {
            Italia nazioneUE = (Italia)nazione;
            Console.WriteLine($"Calcola lo spread di {nazioneUE.Name}");
        }
    }
}
