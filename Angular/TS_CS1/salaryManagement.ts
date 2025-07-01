// Enum for Departments
enum Department {
    HR = "HR",
    IT = "IT",
    Sales = "Sales"
}

// Interface for Employee
interface Employee {
    name: string;
    age: number;
    department: Department;
    baseSalary: number;
    netSalary?: number;
    category?: string;
}

// Function to calculate bonus
function getBonus(department: Department, salary: number): number {
    let bonus = 0;
    if (department === Department.HR) {
        bonus = salary * 0.10;
    } else if (department === Department.IT) {
        bonus = salary * 0.15;
    } else if (department === Department.Sales) {
        bonus = salary * 0.12;
    }
    return bonus;
}

// Function to categorize employee
function getCategory(netSalary: number): string {
    if (netSalary >= 80000) {
        return "High Earner";
    } else if (netSalary >= 50000) {
        return "Mid Earner";
    } else {
        return "Low Earner";
    }
}

// Create employees
const employees: Employee[] = [
    { name: "Ravi", age: 28, department: Department.IT, baseSalary: 60000 },
    { name: "Priya", age: 32, department: Department.HR, baseSalary: 48000 },
    { name: "Arjun", age: 26, department: Department.Sales, baseSalary: 85000 }
];

// Process each employee
for (const emp of employees) {
    const bonus = getBonus(emp.department, emp.baseSalary);
    emp.netSalary = emp.baseSalary + bonus;
    emp.category = getCategory(emp.netSalary);

    // Display details
    console.log(`Name: ${emp.name}`);
    console.log(`Age: ${emp.age}`);
    console.log(`Department: ${emp.department}`);
    console.log(`Base Salary: ₹${emp.baseSalary}`);
    console.log(`Net Salary: ₹${emp.netSalary}`);
    console.log(`Category: ${emp.category}`);
    console.log("---------------------------");
}
