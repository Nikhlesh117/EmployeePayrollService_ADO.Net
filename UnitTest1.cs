using EmployeePayrollService;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Using Stored Procedure")]
        public void GivenUpdateQuery_UsingStoredProcedure_ReturnOne()
        {
            EmployeeModel employeeDataManager = new EmployeeModel();
            EmployeeRepo repo = new EmployeeRepo();

            int expected = 30000000;
            employeeDataManager.EmployeeID = 1;
            employeeDataManager.EmployeeName = "Bruce wayne";
            employeeDataManager.BasicPay = 30000000;

            int actual = repo.UpdateSalary(employeeDataManager);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        [TestCategory("Using SQL Query for Male")]
        public void GivenGenderMale_GroupBygender_ReturnAggregateFunction()
        {
            EmployeeModel employeeDataManager = new EmployeeModel();
            string expected = "30250000 250000 30000000 15125000 2";
            string query = "select sum(BasicPay) as TotalSalary,min(BasicPay) as MinimumSalary,max(BasicPay) as MaximumSalary,Round(avg(BasicPay), 0) as AverageSalary,Count(BasicPay) as Count from employee_payroll where Gender = 'M' group by Gender";
            string actual = EmployeeRepo.AggregateFunctionBasedOnGender(query);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        [TestCategory("Using Transaction Query")]
        public void GivenInsertQuery_usingTransaction_returnOne()
        {
            int expected = 1;
            TransactionClass transactionClass = new TransactionClass();
            int actual = transactionClass.InsertIntoTables();
            Assert.AreEqual(actual, expected);
        }
    }

}