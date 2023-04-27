using System;
using System.Runtime.CompilerServices;

namespace DelegateMatrioska
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ESERCIZIO 1
            UtilityClass utility = new UtilityClass();

            //delegate che esegue metodo Sum
            SumDelegate sumDelegate = utility.Sum;

            //delegate che esegue metodo ExecuteSumDelegate
            ExecuteDelegate executeDelegate = utility.ExecuteSumDelegate;

            //metodo che esegue tutto quanto
            utility.Execute(executeDelegate, sumDelegate, 12, 54);

            //ESERCIZIO 2
            Func<int, int, int> numMoltiplication = (int x, int y) =>
            {
                return x * y;
            };

            Func<int, int, bool> numComparison = (int x, int prod) =>
            {
                return prod > x ? true : false;
            };

            Action<bool> displayResult = (bool result) => 
            {
                if (result) Console.WriteLine("Il prodotto è maggiore"); 
            };

            bool result = numComparison(14, numMoltiplication(3, 222));
            displayResult(result);

        }

        //ESERCIZIO 1
        public delegate void ExecuteDelegate(SumDelegate sumDelegate, int x, int y);
        public delegate void SumDelegate(int x, int y);        

        public class UtilityClass
        {
            public void Sum(int x, int y)
            {
                Console.WriteLine(x+y);
            }

            public void ExecuteSumDelegate(SumDelegate sumDelegate, int x, int y)
            {
                sumDelegate(x, y);
            }

            public void Execute(ExecuteDelegate executeDelegate, SumDelegate sumDelegate, int x, int y)
            {
                executeDelegate(sumDelegate, x, y);
            }
        }
    }
}
