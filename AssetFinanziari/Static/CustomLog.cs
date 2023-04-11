using AssetFinanziari.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetFinanziari.Static
{
    internal class CustomLog
    {
        static string _dir = "D:\\Corso-c#-CGM\\Alex.Exercises\\Log";
        static string _fileName = "Operation.txt";

        public static string Dir { get { return _dir; } }
        public static string FileName { get { return _fileName; } }

        public static void WriteLog(string dir, string fileName, string[] content)
        {
            StringBuilder sb = new StringBuilder();

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            for (int i = 0; i < content.Length; i++)
            {
                if (i == content.Length - 1) 
                    sb.AppendLine(content[i]);
                else
                    sb.Append(content[i]);
            }

            File.AppendAllText(Path.Combine(dir, fileName), sb.ToString());
        }

        public static void DeleteLogFile(string dir, string fileName)
        {
            File.Delete(Path.Combine(dir, fileName));
        }
    }
}
