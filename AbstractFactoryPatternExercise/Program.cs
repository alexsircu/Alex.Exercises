using System;
using AbstractFactoryPatternExercise.Abstract;
using AbstractFactoryPatternExercise.Factories;

namespace AbstractFactoryPatternExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CompanyFactory
            AbstractFactory companyFactory = ClientFactoryProducer.GetFactory(true);
            IProduct airplane = companyFactory.GetProduct("AIRPLANE");
            airplane.Get();
            IProduct train = companyFactory.GetProduct("TRAIN");
            train.Get();
            IProduct bus = companyFactory.GetProduct("BUS");
            bus.Get();

            //CovidFactory
            AbstractFactory covidFactory = ClientFactoryProducer.GetFactory(false);
            IProduct travelDocument = covidFactory.GetProduct("TRAVEL DOCUMENT");
            travelDocument.Get();
            IProduct zoneInfo = covidFactory.GetProduct("ZONE INFO");
            zoneInfo.Get();
        }
    }
}
