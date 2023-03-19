namespace EmployeePayrollService
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Employee Payroll Service ADO.Net");

            EmployeeModel employeeModel = new EmployeeModel();

            EmployeeRepo employeeRepo = new EmployeeRepo();

            employeeModel.EmployeeName = "Bruce wayne";
            employeeModel.PhoneNumber = "1234585645";
            employeeModel.Address = "street 12t";
            employeeModel.Department = "Detective";
            employeeModel.Gender = 'M';
            employeeModel.BasicPay = 22000.00;
            employeeModel.Deductions = 1500.00;
            employeeModel.TaxablePay = 200.00;
            employeeModel.Tax = 300.00;
            employeeModel.NetPay = 2500.00;
            employeeModel.City = "Gotham";
            employeeModel.Country = "India";

            //employeeRepo.AddEmployee(employeeModel);
            employeeRepo.GetAllEmployee();
        }
    }
}
