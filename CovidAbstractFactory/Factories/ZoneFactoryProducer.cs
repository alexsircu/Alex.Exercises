using CovidAbstractFactory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidAbstractFactory.Factories
{
    internal class ZoneFactoryProducer
    {
        public static AbstractFactory GetFactory(int europeanCovidPositives)
        {
            if (europeanCovidPositives < 100000) return new GreenZoneFactory(); 
            if (europeanCovidPositives >= 100000 && europeanCovidPositives < 200000) return new YellowZoneFactory();
            if (europeanCovidPositives >= 200000) return new RedZoneFactory();
            return null;
        }
    }
}
