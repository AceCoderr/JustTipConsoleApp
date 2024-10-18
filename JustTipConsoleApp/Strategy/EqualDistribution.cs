using JustTipConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTipConsoleApp.Strategy
{
    //Strategy 1 - Proportional Distribution to calculate tips based on worked hours by the employees
    internal class EqualDistribution : ITipCalcStrategy
    {
        //Implemets logic to calculate tips according to proportional distribution algorithm
        public List<Employee> CalculateTips(List<Employee> employees, decimal totalTips)
        {
            int totalNumberOfEmployees = employees.Count();

            foreach (var employee in employees)
            {
                if (totalNumberOfEmployees > 0)
                {
                    employee.Tips = totalTips/totalNumberOfEmployees;
                }
                else
                {
                    employee.Tips = 0;
                }
            }

            return employees;
        }
    }
}
