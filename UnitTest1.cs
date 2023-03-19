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
    }
    }
}