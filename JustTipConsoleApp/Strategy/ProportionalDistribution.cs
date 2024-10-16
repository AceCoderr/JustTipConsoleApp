using JustTipConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTipConsoleApp.Strategy
{
    //Strategy 1 - Proportional Distribution to calculate tips based on worked hours by the employees
    internal class ProportionalDistribution : ITipCalcStrategy
    {
        //Implemets logic to calculate tips according to proportional distribution algorithm
        public void CalculateTips(List<Employee> employees, float totalTips)
        {

        }
    }
}
