using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InCamp_Test_Task
{
    class Program
    {
        const string InputPath = @"d:\study\acme_worksheet.csv";
        const string OutputPath = @"d:\study\acme_worksheet_output.csv";
        const string Delimeter = ",";
        const string DefaultValue = "0";
        const string Keyword = "Employee Name";
        const string Keyword_2 = "Name / Date";

        static List<string> prepareData(List<Employee> employees)
        {
            List<string> output = new List<string>();

            if(employees.Count == 0)
            {
                Console.WriteLine("The input list is empty");
                return output;
            }

            if (employees.First().getName() == Keyword)
            {
                employees.RemoveAt(0);
            }

            HashSet<string> names = new HashSet<string>();
            HashSet<string> dates = new HashSet<string>();

            foreach (var em in employees)
            {
                names.Add(em.getName());
                dates.Add(em.getDate());
            }

            int countNames = names.Count();
            int countDates = dates.Count();

            string[] strNames = names.ToArray();
            string[] strDates = dates.ToArray();

            string[,] data = new string[countNames + 1, countDates + 1];
            for (int i = 0; i <= names.Count; i++)
            {
                for (int j = 0; j <= dates.Count; j++)
                {
                    data[i, j] = DefaultValue;
                }
            }

            data[0, 0] = Keyword_2;

            int counter = 1;
            foreach (var n in names)
            {
                data[counter, 0] = n;
                counter++;
            }

            counter = 1;
            foreach (var d in dates)
            {
                data[0, counter] = d;
                counter++;
            }

            for (int i = 1; i <= names.Count; i++)
            {
                for (int j = 1; j <= dates.Count; j++)
                {
                    foreach (var em in employees)
                    {
                        if (em.getName() == data[i, 0] && em.getDate() == data[0, j])
                        {
                            data[i, j] = em.getHours();
                            continue;
                        }
                    }
                }
            }

            for (int i = 0; i <= names.Count; i++)
            {
                string row = "";
                for (int j = 0; j < dates.Count; j++)
                {
                    row += data[i, j] + Delimeter;
                }
                row += data[i, countDates];
                output.Add(row);
            }

            return output;
        }

        static void Main(string[] args)
        {
            List<string> data = prepareData(CSVManager.readCSV(InputPath, Delimeter));
            CSVManager.writeCSV(OutputPath, data);
            Console.ReadKey();
        }
    }
}
