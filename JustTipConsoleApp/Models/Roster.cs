using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTipConsoleApp.Models
{
    internal class Roster
    {
        private string rosterName {  get; set; }

        private List<Employee> employees = new List<Employee>();

        private decimal totalHoursWorked {  get; set; }

        public List<Employee> GetEmployeesList()
        {
            return employees;
        }
        public string GetRosterName()
        {
            return rosterName;
        }
        public void SetRosterName(string name)
        {
             this.rosterName = name;
        }
        public void AssignEmployeeToRoster(Employee emp)
        {
            employees.Add(emp);
        }

        //Total hours worked by the employees in a particular roster.
        public decimal CalculateTotalHoursWorked()
        {
            foreach (Employee emp in employees)
            {
               totalHoursWorked +=  emp.EmployeeTotalHoursWorked();
            }
            return totalHoursWorked;
        }
    }
}
