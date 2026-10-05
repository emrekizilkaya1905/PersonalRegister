namespace PersonalRegister
{
    public class EmployeeRegister
    {
        private readonly List<Employee> _employees = new ();
        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee cannot be null.");
            }
            _employees.Add(employee);
        }
       
        public IReadOnlyList<Employee> GetAllEmployees()
        {
            return _employees.AsReadOnly();
        }
    }
}
