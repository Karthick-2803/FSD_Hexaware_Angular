using EmployeeManagement.models;
using EmployeeManagement.Service;

namespace EmployeeManagement
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Sample Employee object
            Employee emp = new Employee
            {
                EmpCode = 101,
                EmpName = "Alice",
                Email = "alice@abc.com",
                DeptName = "Development",
                Location = "Pune"
            };

            // Full Time Employee
            FullTimeEmployee fte = new FullTimeEmployee
            {
                Basic = 30000
            };
            fte.CalculateSalary();
            Console.WriteLine(fte.PrintEmployeeDetails(emp));
            Console.WriteLine($"Net Salary (FTE): {fte.NetSalary}");

            // Part Time Employee
            PartTimeEmployee pte = new PartTimeEmployee
            {
                Basic = 15000
            };
            pte.CalculateSalary();
            Console.WriteLine(pte.PrintEmployeeDetails(emp));
            Console.WriteLine($"Net Salary (PTE): {pte.NetSalary}");
        }
    }
}

