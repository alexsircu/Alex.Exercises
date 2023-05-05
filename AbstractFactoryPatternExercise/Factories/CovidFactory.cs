using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryPatternExercise.Abstract;
using AbstractFactoryPatternExercise.Products;

namespace AbstractFactoryPatternExercise.Factories
{
    internal class CovidFactory : AbstractFactory
    {
        public override IProduct GetProduct(string productType)
        {
            if (productType == null) return null;

            if (productType.Equals("TRAVEL DOCUMENT")) return new TravelDocument();
            if (productType.Equals("ZONE INFO")) return new ZoneInfo();
            return null;
        }
    }
}
