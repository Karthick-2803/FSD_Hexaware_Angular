using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Interfaces;
using EmployeeManagement.models;

namespace EmployeeManagement.Service
{
    public class FullTimeEmployee : IFullTimeEmployee
    {
        public double Basic { get; set; }
        public double Hra { get; set; }
        public double Da { get; set; }
        public double NetSalary { get; set; }

        public double CalculateSalary()
        {
            Hra = Basic * 0.15;
            Da = Basic * 0.10;
            NetSalary = Basic + Hra + Da;
            return NetSalary;
        }

        public string PrintEmployeeDetails(Employee emp)
        {
            return $"[FTE] EmpCode: {emp.EmpCode}, Name: {emp.EmpName}, Email: {emp.Email}, Dept: {emp.DeptName}, Location: {emp.Location}";
        }
    }
}
