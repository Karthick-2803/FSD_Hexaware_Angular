using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Interfaces;
using EmployeeManagement.models;

namespace EmployeeManagement.Service
{
    public class PartTimeEmployee : IPartTimeEmployee
    {
        public double Basic { get; set; }
        public double Da { get; set; }
        public double NetSalary { get; set; }

        public double CalculateSalary()
        {
            Da = Basic * 0.05;
            NetSalary = Basic + Da;
            return NetSalary;
        }

        public string PrintEmployeeDetails(Employee emp)
        {
            return $"[PTE] EmpCode: {emp.EmpCode}, Name: {emp.EmpName}, Email: {emp.Email}, Dept: {emp.DeptName}, Location: {emp.Location}";
        }
    }
}
