using PersonalRegister;
using System.Globalization;

var culture = CultureInfo.GetCultureInfo("sv-SE");
var employeeRegister = new EmployeeRegister();

while (true)
{
    Console.WriteLine("\n--- Employee Register ---");
    Console.WriteLine("1. Add employee");
    Console.WriteLine("2. List employees");
    Console.WriteLine("0. Exit");
    Console.Write("Your choice: "); 
    string? choice = Console.ReadLine()?.Trim();
    
    if(choice == null || choice == "0")
    {
        Console.WriteLine("Exiting...");
        break;
    }
    switch(choice)
    {
        case "1":
            Console.Write("Enter employee name: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
                break;
            }
            Console.Write("Enter employee salary in SEK (e.g. 25000,50; no thousands separators): ");
            string? salaryInput = Console.ReadLine();
            if (!decimal.TryParse(salaryInput, (NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint), culture, out decimal salary) || salary < 0)
            {
                Console.WriteLine("Invalid salary. Use a non-negative number with a decimal comma, e.g. 25000,50.");
                break;
            }
            var employee = new Employee(name, salary);
            employeeRegister.AddEmployee(employee);
            Console.WriteLine($"Employee {employee.Name} added successfully.");
            break;
        case "2":
            var employees = employeeRegister.GetAllEmployees();
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees registered.");
            }
            else
            {
                Console.WriteLine("\n--- Registered Employees ---");
                foreach (var emp in employees)
                {
                    Console.WriteLine($"Name: {emp.Name}, Salary: {emp.Salary.ToString("N2", culture)} SEK");
                }
            }
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}