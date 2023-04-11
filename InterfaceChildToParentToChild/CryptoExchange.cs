using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceChildToParentToChild
{
    internal class CryptoExchange : ICryptoIntermediary
    {
        public void BuyCrypto() 
        {
            Console.WriteLine("Ciao");
        }
    }
}
