﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTipConsoleApp.Models
{
    public class Employee
    {
        private string? EmployeeName { get; set; }
        List<Shift> shifts = new List<Shift>();
        public  decimal Tips { get; set; }

        public void setEmployeeName(string? _employeeName)
        {
            this.EmployeeName = _employeeName;
        }
        public string getEmployeeName()
        {
            return EmployeeName;
        }
        public void AssignShiftToEmployee(Shift shift)
        {
            shifts.Add(shift);
        }

        public decimal EmployeeTotalHoursWorked()
        {
            return shifts.Sum(s => s.ShiftDurationInHours());
        }
    }
}
