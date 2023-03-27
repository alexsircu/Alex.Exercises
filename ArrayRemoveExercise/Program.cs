using System;

namespace ArrayRemoveExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Fiat", 5);
            car.RemoveOwner("Elena");

            car.addOwner("mario");
            car.addOwner("stefano");
            car.addOwner("giuseppe");
            car.addOwner("peppino");
            car.addOwner("elena");
            car.addOwner("ilaria");
            car.addOwner("matteo");
        }

        class Car
        {
            //const int TotOwners = 4; // di istanza 
            string _name;
            string[] _owners;
            int counter;
            public Car(string Name, int totOwners)
            {
                _name = Name;
                _owners = new string[totOwners];
            }

            public void addOwner(string Name)
            {
                if (counter < _owners.Length)
                {
                    _owners[counter] = Name;
                }
                else
                {
                    string[] owners2 = new string[counter + 1];
                    Array.Copy(_owners, owners2, _owners.Length);
                    _owners = owners2;
                    _owners[counter] = Name;
                }
                counter++;
            }
            public void RemoveOwner(string Name)
            {
                Person[] items = new Person[] {
                new Person() { Name = "Bruno" } ,
                new Person() { Name = "Marco" },
                new Person() { Name = "Elena" },
                new Person() { Name = "Mario" },
                new Person() { Name = "Fabio" },
               };

                var person = Array.Find(items, item => item.Name == Name);
                var index = Array.IndexOf(items, person);
                items[index].Name = null;

                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine(items[i].Name);
                }

            }
        }

        class Person
        {
            public string Name { get; set; }
        }
    }
}
