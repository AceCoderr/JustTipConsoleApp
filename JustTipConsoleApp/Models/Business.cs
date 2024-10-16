﻿using JustTipConsoleApp.Strategy;
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

        private float TotalTips = 0;

        public void seTotalTips(float totalTips)
        {
            this.TotalTips = totalTips;
        }
        public Business(ITipCalcStrategy strategy)
        {
            this.tipCalcStrategy = strategy;
        }
        public void AddEmployee()
        {
            Employee newEmployee = new Employee();
            Console.WriteLine("Enter Name");
            newEmployee.setEmployeeName(Console.ReadLine());
            employees.Add(newEmployee); 
        }

        public void CreateRoster()
        {
            Roster newRoster = new Roster();
            Console.WriteLine("Enter Roster Name");
            string rosterName = Console.ReadLine();
            newRoster.SetRosterName(rosterName);

            rosters.Add(newRoster);
        }

        public void AssignEmployeesToRoster(string rosName,string empName)
        {
            var employee = employees.FirstOrDefault(e => e.getEmployeeName() == empName);
            var roster = rosters.FirstOrDefault(r=>r.GetRosterName() == rosName);
            if (employee != null)
            {
                Console.WriteLine("Enter Shift Start Time (yyyyy-MM-dd HH:mm): ");
                DateTime start = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter Shift End Time (yyyy-MM-dd HH:mm): ");
                DateTime end = DateTime.Parse(Console.ReadLine());

                Shift newShift = new Shift(start,end);

                employee.AssignShiftToEmployee(newShift);
            }
            roster.AssignEmployeeToRoster(employee);
        }
        public void DistributeTip()
        {
            if (employees.Count > 0)
            {
                throw new InvalidOperationException("No employees to distribute tips to.");
            }

            tipCalcStrategy.CalculateTips(employees,TotalTips)
        }
    }
}