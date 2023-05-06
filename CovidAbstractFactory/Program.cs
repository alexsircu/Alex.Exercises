using CovidAbstractFactory.Abstract;
using CovidAbstractFactory.Factories;
using System;

namespace CovidAbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //green
            Europa.CovidPositives = 40434;
            AbstractFactory greenZoneFactory = ZoneFactoryProducer.GetFactory(Europa.CovidPositives);
            //yellow
            Europa.CovidPositives = 140345;
            AbstractFactory yellowZoneFactory = ZoneFactoryProducer.GetFactory(Europa.CovidPositives);
            //red
            Europa.CovidPositives = 1503223;
            AbstractFactory redZoneFactory = ZoneFactoryProducer.GetFactory(Europa.CovidPositives);
        }
    }
}
