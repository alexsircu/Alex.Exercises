using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternExercise.Abstract
{
    internal abstract class AbstractFactory
    {
        public abstract IProduct GetProduct(string product);
    }
}
