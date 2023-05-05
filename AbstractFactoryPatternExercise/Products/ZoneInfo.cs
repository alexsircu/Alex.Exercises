using AbstractFactoryPatternExercise.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternExercise.Products
{
    internal class ZoneInfo : IProduct
    {
        public void Get()
        {
            Console.WriteLine("Zone info");
        }
    }
}
