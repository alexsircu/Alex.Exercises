using System;
using static DelegateMatrioska.Program;

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
            functionClass.Execute(executeDelegate, sumDelegate);
        }

        public delegate void ExecuteDelegate(SumDelegate sumDelegate);
        public delegate void SumDelegate(int x, int y);        

        public class FunctionClass
        {
            public void Sum(int x, int y)
            {
                Console.WriteLine(x+y);
            }

            public void ExecuteSumDelegate(SumDelegate sumDelegate)
            {
                sumDelegate(12, 45);
            }

            public void Execute(ExecuteDelegate executeDelegate, SumDelegate sumDelegate)
            {
                executeDelegate(sumDelegate);
            }
        }
    }
}
