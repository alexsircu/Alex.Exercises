using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace DescAscGenericsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string
            List<string> stringData = new List<string>
            {
                "fdg",
                "wer",
                "asdf",
                "yt",
                "jhlhj",
                "bhj",
                "iour"
            };

            //int
            List<int> intData = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                intData.Add(new Random().Next(0, 100));
            }

            //obj
            List<Person> personData = new List<Person>();
            Person matteo = new Person() { Name = "Matteo", Surname = "m", Age = 25 };
            Person fausto = new Person() { Name = "Fausto", Surname = "f", Age = 30 };
            Person mario = new Person() { Name = "Mario", Surname = "m", Age = 40 };
            Person alessio = new Person() { Name = "Alessio", Surname = "a", Age = 55 };
            personData.Add(alessio);
            personData.Add(matteo);
            personData.Add(mario);
            personData.Add(fausto);

            //order method
            var newData = DataManagement.Order(intData, "ASC");

            for (int i = 0; i < newData.Count; i++)
            {
                Console.WriteLine(newData[i]);
            }
        }

        public static class DataManagement
        {
            public static List<T> Order<T>(List<T> data, string order, string property)
            {
                if (order == "ASC")
                {
                    data = data.OrderBy(item => item.GetType().GetProperty(property).GetValue(item)).ToList();
                }
                if (order == "DESC")
                {
                    data = data.OrderByDescending(item => item.GetType().GetProperty(property).GetValue(item)).ToList();
                }

                return data;
            }

            public static List<T> Order<T>(List<T> data, string order)
            {
                if (order == "ASC")
                {
                    data.Sort();
                }
                if (order == "DESC")
                {
                    data.Sort();
                    data.Reverse();
                }

                return data;
            }
        } 

        public class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }
        }
        
    }
}
