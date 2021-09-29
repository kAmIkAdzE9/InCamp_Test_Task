using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InCamp_Test_Task
{
    class CSVManager
    {
        public static List<Employee> readCSV(string path, string delimeter)
        {
            List<Employee> input_data = new List<Employee>();
            try
            {
                using (TextFieldParser parser = new TextFieldParser(path))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(delimeter);

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        input_data.Add(new Employee(fields[0], fields[1], fields[2]));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            return input_data;
        }

        public static void writeCSV(string path, List<string> output)
        {
            try
            {
                using (var w = new StreamWriter(path))
                {
                    foreach (var s in output)
                    {
                        w.WriteLine(s);
                        w.Flush();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
        }
    }
}
