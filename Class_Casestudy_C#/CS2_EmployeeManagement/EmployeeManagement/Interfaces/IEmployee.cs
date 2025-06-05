using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.models;

namespace EmployeeManagement.Interfaces
{
    public interface IEmployee<T> where T : Employee
    {
        string PrintEmployeeDetails(T employee);
    }
}
