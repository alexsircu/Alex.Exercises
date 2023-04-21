using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace GenericsFileManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "D:\\Corso-c#-CGM\\Alex.Exercises\\GenericsFileManagement\\Log\\file.csv";

            Person alessio = new Person { Name = "Alessio", Surname = "Presciuttini", CF = "dsfhsdjghe48w" };
            Person matteo = new Person { Name = "Matteo", Surname = "Luccisano", CF = "tytgfdsgert" };
            Person cristina = new Person { Name = "Cristina", Surname = "Zappalà", CF = "34fdh345tr" };
            Person fausto = new Person { Name = "Fausto", Surname = "Boshoff", CF = "bmyjhwrtyhg45" };

            List<Person> people = new List<Person>
            {
                alessio,
                matteo,
                cristina,
                fausto
            };

            //TextFileGenerator.SaveToFile(people, filePath);
            TextFileGenerator.LoadFromCSVFile(alessio, filePath);
        }

        public static class TextFileGenerator
        {

            // Serialization 
            public static void SaveToFile<T>(List<T> data, string filePath)
            {
                StringBuilder line = new StringBuilder();

                //check
                if (data == null || data.Count == 0) return;

                //retrieve properties
                var cols = data[0].GetType().GetProperties(); 

                //file not exists create header
                if (!File.Exists(filePath))
                {
                    foreach (var col in cols)
                    {
                        string propName = col.Name;
                        line.Append(propName);

                        if (col != cols.Last())
                        {
                            line.Append(';');
                        } 
                        else
                        {
                            line.Append('\n');
                        }
                    }

                    File.AppendAllText(filePath, line.ToString());
                }

                //create rows 
                foreach (var row in data)
                {
                    line = new StringBuilder();

                    foreach (var col in cols)
                    { 
                        var value = col.GetValue(row);
                        line.Append(value);

                        if (col != cols.Last())
                        {
                            line.Append(';');
                        }
                        else
                        {
                            line.Append('\n');
                        }
                    }

                    File.AppendAllText(filePath, line.ToString());
                }
            }

            // Deserialization 
            public static List<T> LoadFromCSVFile<T>(T data, string filePath) where T : class, new()
            {


                //1 header confronto con data per verificare che l'oggetto in questione può essere trovato nel file 

                string[] rows = File.ReadAllLines(filePath);
                var cols = data.GetType().GetProperties();

                List<T> list = new List<T>();

                foreach (var row in rows)
                {

                    T obj = new();
                    string[] rowWords = new string[cols.Length];

                    if (row != rows.First())
                    {
                        rowWords = row.Split(',');
                    }

                    foreach (var word in rowWords)
                    {
                        foreach (var col in cols)
                        {

                            var convertedValue = Convert.ChangeType(word, col.PropertyType);



                            col.SetValue(data, convertedValue);

                        }
                    }


                    
                }

                






                Console.WriteLine("Ciao");
                return list;
            }

        }

        public class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string CF { get; set; }
        }
    }
}
