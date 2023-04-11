using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace AssetFinanziari.Abstract
{
    internal abstract class Person
    {
        string _name;
        string _surname;
        string _id;
        string _sex;
        DateTime _birthday;

        public string Name { get { return _name; } set { _name = value; } }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public string ID { get { return _id; } set { _id = value; } }
        public string Sex { get { return _sex; } set { _sex = value; } }
        public DateTime Birthday { get { return _birthday; } set { _birthday = value; } }
        public int Age { get { return DateTime.Now.Year - Birthday.Year; } }
        public string FullName { get { return _name + " " + _surname; } }

        public Person(string name, string surname, string id, DateTime birthday, string sex)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Sex = sex;
            ID = id;
        }
    }
}