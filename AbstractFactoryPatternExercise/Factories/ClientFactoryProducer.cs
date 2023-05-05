using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryPatternExercise.Abstract;

namespace AbstractFactoryPatternExercise.Factories
{
    internal class ClientFactoryProducer
    {
        public static AbstractFactory GetFactory(bool travelCompany)
        {
            if (travelCompany)
            {
                return new CompanyFactory();
            }
            else
            {
                return new CovidFactory();
            }
        }
    }
}
