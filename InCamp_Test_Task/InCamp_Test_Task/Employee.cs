using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InCamp_Test_Task
{
    class Employee
    {
        string name;
        string date;
        string hours;

        public string getName()
        {
            return name;
        }

        public string getDate()
        {
            return date;
        }

        public string getHours()
        {
            return hours;
        }

        public Employee(string name, string date, string hours)
        {
            this.name = name;
            this.date = date;
            this.hours = hours;
        }
    }
}
