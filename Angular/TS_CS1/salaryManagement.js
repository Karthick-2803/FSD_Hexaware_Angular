// Enum for Departments
var Department;
(function (Department) {
    Department["HR"] = "HR";
    Department["IT"] = "IT";
    Department["Sales"] = "Sales";
})(Department || (Department = {}));
// Function to calculate bonus
function getBonus(department, salary) {
    var bonus = 0;
    if (department === Department.HR) {
        bonus = salary * 0.10;
    }
    else if (department === Department.IT) {
        bonus = salary * 0.15;
    }
    else if (department === Department.Sales) {
        bonus = salary * 0.12;
    }
    return bonus;
}
// Function to categorize employee
function getCategory(netSalary) {
    if (netSalary >= 80000) {
        return "High Earner";
    }
    else if (netSalary >= 50000) {
        return "Mid Earner";
    }
    else {
        return "Low Earner";
    }
}
// Create employees
var employees = [
    { name: "Ravi", age: 28, department: Department.IT, baseSalary: 60000 },
    { name: "Priya", age: 32, department: Department.HR, baseSalary: 48000 },
    { name: "Arjun", age: 26, department: Department.Sales, baseSalary: 85000 }
];
// Process each employee
for (var _i = 0, employees_1 = employees; _i < employees_1.length; _i++) {
    var emp = employees_1[_i];
    var bonus = getBonus(emp.department, emp.baseSalary);
    emp.netSalary = emp.baseSalary + bonus;
    emp.category = getCategory(emp.netSalary);
    // Display details
    console.log("Name: ".concat(emp.name));
    console.log("Age: ".concat(emp.age));
    console.log("Department: ".concat(emp.department));
    console.log("Base Salary: \u20B9".concat(emp.baseSalary));
    console.log("Net Salary: \u20B9".concat(emp.netSalary));
    console.log("Category: ".concat(emp.category));
    console.log("---------------------------");
}
