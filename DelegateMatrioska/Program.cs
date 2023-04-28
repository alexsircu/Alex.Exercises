using System;
using System.Collections.Generic;
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

            //ESERCIZIO 3
            EUDigitalWallet wallet = new EUDigitalWallet("mario", "rossi", "msdgdkjfg2345r", "dignitosamente sano");
            InsuranceInstitution insurance = new InsuranceInstitution();

            bool planIsCreated = insurance.CreatePlan(wallet.GetClinicalSituation());
            if (planIsCreated)
            { 
                Console.WriteLine(insurance.GetData().Situation);
                wallet.UpdateClinicalSituation("sano come un pesce");
                Console.WriteLine(insurance.GetData().Situation);
            }
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

        //ESERCIZIO 3
        public abstract class EUEntity
        {
            public class ClinicalSituation
            {
                string _situation;

                public string Situation { get { return _situation; } set { _situation = value; } }

                public ClinicalSituation(string situation)
                {
                    _situation = situation;
                }
            }
        }

        public class EUDigitalWallet : EUEntity
        {
            string _name;
            string _surname;
            string _cf;
            ClinicalSituation _situation;

            public EUDigitalWallet(string name, string surname, string cf, string situation)
            {
                _name = name;
                _surname = surname;
                _cf = cf;
                _situation = new ClinicalSituation(situation);
            }

            public ClinicalSituation GetClinicalSituation()
            {
                //gestisce tutta la clinical situation
                return _situation;
            }

            public void UpdateClinicalSituation(string situation)
            {
                _situation.Situation = situation;
            }
        }

        public class InsuranceInstitution : EUEntity
        {
            List<ClinicalSituation> _clinicalSituations = new List<ClinicalSituation>();
            public bool CreatePlan(ClinicalSituation data)
            {
                bool isTrue = askClient();
                if (!isTrue)
                {
                    Console.WriteLine("Non hai accettato di inviare i dati sanitari, non puoi procedere");
                    return false;
                } 
                    
                _clinicalSituations.Add(data);
                return true;
            }

            private bool askClient()
            {
                Console.WriteLine("Accetti di inviare i dati sanitari?");
                string input = Console.ReadLine();
                input.ToLower();

                if (input == "si" || input == "yes") return true;
                return false;
            }

            public ClinicalSituation GetData()
            {
                return _clinicalSituations[0];
            }
        }
    }
}
