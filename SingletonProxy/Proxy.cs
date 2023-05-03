using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonProxy
{
    internal class Proxy
    {
        static Proxy _proxyInstance;
        List<int> _ipList;

        private Proxy()
        {
            _ipList = new List<int>();
            Random random = new Random();

            for (int i = 0; i < 4; i++) 
            {
                _ipList.Add(random.Next(1000000, 10000000));
            }
        }

        public static Proxy GetProxy()
        {
            if (_proxyInstance == null) _proxyInstance = new Proxy();

            return _proxyInstance;
        }

        public void GetIpList()
        {
            _ipList.ForEach(ip => { Console.WriteLine(ip); });
        }

        public int GetIp()
        {
            Random random = new Random();
            int num = random.Next(0, _ipList.Count);
            return _ipList[num];
        }
    }
}
