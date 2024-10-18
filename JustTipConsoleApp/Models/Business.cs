using JustTipConsoleApp.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace JustTipConsoleApp.Models
{
    internal class Business
    {
        private List<Employee> employees = new List<Employee>();
        private List<Roster> rosters = new List<Roster>();
        public ITipCalcStrategy tipCalcStrategy;

        private decimal TotalTips = 0;

        public void seTotalTips(decimal totalTips)
        {
            this.TotalTips = totalTips;
        }
        public Business(ITipCalcStrategy strategy)
        {
            this.tipCalcStrategy = strategy;
        }
        public List<Employee> AddEmployee(string empName)
        {
            Employee newEmployee = new Employee();
            newEmployee.setEmployeeName(empName);
            employees.Add(newEmployee);
            return employees;
        }

        public List<Roster> CreateRoster(string rosName)
        {
            Roster newRoster = new Roster();
            
            newRoster.SetRosterName(rosName);

            rosters.Add(newRoster);
            return rosters;
        }

        public Roster AssignEmployeesToRoster(string rosName,string empName,DateTime start,DateTime end)
        {
            var employee = employees.FirstOrDefault(e => e.getEmployeeName() == empName);
            var roster = rosters.FirstOrDefault(r=>r.GetRosterName() == rosName);
            if (employee != null)
            {
                Shift newShift = new Shift(start,end);

                employee.AssignShiftToEmployee(newShift);
                if(roster != null)
                {
                    roster.AssignEmployeeToRoster(employee);
                    return roster;
                }
                else
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("-------No Roster found of this name---------");
                    Console.WriteLine("--------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("-------No Employee found of this name-------");
                Console.WriteLine("--------------------------------------------");
            }
            return roster;
        }
        public List<Employee> DistributeTip(string rosName,decimal totalTips)
        {
            TotalTips = totalTips;
            if (employees.Count <= 0)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("-------No Employees added to businesss------");
                Console.WriteLine("--------------------------------------------");
            }
            if (rosters.Count <= 0)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("-------No Rosters created for businesss------");
                Console.WriteLine("--------------------------------------------");
            }
            var roster = rosters.FirstOrDefault(r => r.GetRosterName() == rosName);
            List<Employee> RosterEmployees = new List<Employee>();
            if (roster != null)
            {
                RosterEmployees = roster.GetEmployeesList();
            }
            else {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("-------No Rosters found of name {rosName}------",rosName);
                Console.WriteLine("--------------------------------------------");
            }
            
            return tipCalcStrategy.CalculateTips(RosterEmployees, TotalTips);
        }
        
        public void ChangeStrategy(string option)
        {
            var choice = int.Parse(option);
            if (choice == 1)
            {
                this.tipCalcStrategy = new ProportionalDistribution();
            }
            else if (choice == 2)
            {
                this.tipCalcStrategy = new EqualDistribution();
            }
            else 
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("-----------Invalid Option Selected----------");
                Console.WriteLine("--------------------------------------------");
            }

        }
        public void ShowTips()
        {
            foreach ( var  employee in employees )
            {
                Console.WriteLine($"{employee.getEmployeeName()} : {employee.Tips}");
            }
        }
    }
}
