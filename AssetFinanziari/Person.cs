using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetFinanziari
{
    public abstract class Person
    {
        string _name;
        string _surname;
        string _sex;
        int _age;

        public string Name { get { return _name; } set { _name = value; } }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public string Sex { get { return _sex; } set { _sex = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public string FullName { get { return _name + " " + _surname; } }
    }
}