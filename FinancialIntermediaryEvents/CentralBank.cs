using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialIntermediaryEvents
{
    internal class CentralBank
    {
        public delegate void ChangeCEOEventHandler(object sender, ChangeCEOEventArgs e);
        public event ChangeCEOEventHandler ChangedCEO;
        CEO _ceo;
        string _name;

        public string Name { get => _name; set => _name = value; } 

        public CEO Ceo { 
            get => _ceo;
            set
            {
                if (_ceo is null) 
                {
                    _ceo = value;
                } 
                else if (!value.Equals(_ceo))
                {
                    ChangeCEOEventArgs e = new ChangeCEOEventArgs(value.Name, value.Surname);
                    ChangedCEO(this, e);
                    _ceo = value;
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
            Console.WriteLine($"{e.Name} {e.Surname} è il nuovo CEO di {sender.GetType().GetProperty("Name").GetValue(sender)}");
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

    internal class ChangeCEOEventArgs : EventArgs
    {
        string _name;
        string _surname;

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }

        public ChangeCEOEventArgs(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }
    }
}
