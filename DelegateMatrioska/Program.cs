using System;

namespace DelegateMatrioska
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FunctionClass functionClass = new FunctionClass();

            //delegate che esegue metodo Sum
            SumDelegate sumDelegate = functionClass.Sum;

            //delegate che esegue metodo ExecuteSumDelegate
            ExecuteDelegate executeDelegate = functionClass.ExecuteSumDelegate;

            //metodo che esegue tutto quanto
            functionClass.Execute(executeDelegate, sumDelegate, 12, 54);
        }

        public delegate void ExecuteDelegate(SumDelegate sumDelegate, int x, int y);
        public delegate void SumDelegate(int x, int y);        

        public class FunctionClass
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
