using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinancialIntermediaryEvents.WithObserverPattern.Intermediary;
using System.Xml.Linq;
using FinancialIntermediaryEvents.Delegates;
using static FinancialIntermediaryEvents.CentralBank;
using static FinancialIntermediaryEvents.WithObserverPattern.Intermediary.CentralBank;

namespace FinancialIntermediaryEvents.WithObserverPattern
{
    internal abstract class Intermediary
    {
        internal class CentralBank : Subject
        {
            CEO _ceo;
            string _name;

            public string Name { get => _name; set => _name = value; }
            public CEO Ceo { get => _ceo;
                set 
                {
                    if (value != _ceo)
                    {
                        _ceo = value;
                        Notify();
                    }
                } 
            }

            public CentralBank(string intermediaryName, string ceoName, string ceoSurname)
            {
                Name = intermediaryName;
                Ceo = new CEO(ceoName, ceoSurname);
            }

            public void ChangeCEO(string name, string surname)
            {
                Ceo = new CEO(name, surname);
            }

            public virtual void NotifyCentralBankCEOChanged(object sender, ChangeCEOEventArgs e)
            {

            }

            internal class CEO
            {
                string _name;
                string _surname;

                public string Name { get => _name; set => _name = value; }
                public string Surname { get => _surname; set => _surname = value; }

                public CEO(string name, string surname)
                {
                    Name = name;
                    Surname = surname;
                }
            }
        }

        internal class CommercialBank : ICustomObserver
        {
            string _name;
            CentralBank _centralBank;
            string _centralBankCeoName;
            string _centralBankCeoSurname;

            public string Name { get => _name; set => _name = value; }
            public CentralBank CentralBank { get => _centralBank; set => _centralBank = value; }
            public string CentralBankCeoName { get => _centralBankCeoName; set => _centralBankCeoName = value; }
            public string CentralBankCeoSurname { get => _centralBankCeoSurname; set => _centralBankCeoSurname = value; }

            public CommercialBank(string intermediaryName, CentralBank centralBank)
            {
                Name = intermediaryName;
                CentralBank = centralBank;
            }

            public void Update()
            {
                CentralBankCeoName = CentralBank.Ceo.Name;
                CentralBankCeoSurname = CentralBank.Ceo.Surname;
                Console.WriteLine($"Observer {Name}'s new state is {CentralBankCeoName} {CentralBankCeoSurname}");
            }
        }

        internal class StockMarket : ICustomObserver
        {
            string _name;
            CentralBank _centralBank;
            string _centralBankCeoName;
            string _centralBankCeoSurname;

            public string Name { get => _name; set => _name = value; }
            public CentralBank CentralBank { get => _centralBank; set => _centralBank = value; }
            public string CentralBankCeoName { get => _centralBankCeoName; set => _centralBankCeoName = value; }
            public string CentralBankCeoSurname { get => _centralBankCeoSurname; set => _centralBankCeoSurname = value; }

            public StockMarket(string intermediaryName, CentralBank centralBank)
            {
                Name = intermediaryName;
                CentralBank = centralBank;
            }
            public void Update()
            {
                CentralBankCeoName = CentralBank.Ceo.Name;
                CentralBankCeoSurname = CentralBank.Ceo.Surname;
                Console.WriteLine($"Observer {Name}'s new state is {CentralBankCeoName} {CentralBankCeoSurname}");
            }
        }

        internal abstract class Subject
        {
            private List<ICustomObserver> observers = new List<ICustomObserver>();
            public void Attach(ICustomObserver observer)
            {
                observers.Add(observer);
            }
            public void Detach(ICustomObserver observer)
            {
                observers.Remove(observer);
            }
            public void Notify()
            {
                foreach (ICustomObserver o in observers)
                {
                    o.Update();
                }
            }
        }

        internal interface ICustomObserver
        {
            public void Update();
        }
    }
}
