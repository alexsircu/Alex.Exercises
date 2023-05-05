using AbstractFactoryPatternExercise.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternExercise.Products
{
    internal class TrainCompany : IProduct
    {
        public void Get()
        {
            Console.WriteLine("Train company");
        }
    }
}
