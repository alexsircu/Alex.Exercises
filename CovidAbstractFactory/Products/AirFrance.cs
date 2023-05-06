using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidAbstractFactory.Abstract;

namespace CovidAbstractFactory.Products
{
    internal class AirFrance : ICompany
    {
        public void Get()
        {
            Console.WriteLine("AirFrance");
        }
    }
}
