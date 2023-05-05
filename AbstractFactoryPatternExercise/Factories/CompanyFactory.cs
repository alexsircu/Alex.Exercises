using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryPatternExercise.Abstract;
using AbstractFactoryPatternExercise.Products;

namespace AbstractFactoryPatternExercise.Factories
{
    internal class CompanyFactory : AbstractFactory
    {
        public override IProduct GetProduct(string productType)
        {
            if (productType == null) return null;

            if (productType.Equals("AIRPLANE")) return new AirplaneCompany();
            if (productType.Equals("TRAIN")) return new TrainCompany();
            if (productType.Equals("BUS")) return new BusCompany();
            return null;
        }
    }
}
