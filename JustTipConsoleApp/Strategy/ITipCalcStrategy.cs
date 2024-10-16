using JustTipConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTipConsoleApp.Strategy
{
    //Interface to create Tip Calculation Strategy
    public interface ITipCalcStrategy
    {
        void CalculateTips(List<Employee> employees, float totalTips);   // Place holder Method - no logic
    }
}
