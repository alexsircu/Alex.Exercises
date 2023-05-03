using System;

namespace SingletonProxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy = Proxy.GetProxy();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(proxy.GetIp());
            }

            Console.WriteLine("------------------");
            Console.WriteLine("Lista di IP");
            proxy.GetIpList();

            Console.WriteLine("-------------------");
            Console.WriteLine("Proxy 2");
            Proxy proxy1 = Proxy.GetProxy();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(proxy.GetIp());
            }

            Console.WriteLine("------------------");
            Console.WriteLine("Lista di IP proxy 2");
            proxy.GetIpList();
        }
    }
}
