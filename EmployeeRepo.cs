using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@Country", model.Country);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }

        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    //string query = @"Select EmployeeName,PhoneNumber,Address,Department,Gender,BasicPay,Deductions,TaxablePay,Tax,NetPay," +
                    //    "StartDate,City,Country from employee";

                    string query = @"Select * from employee";

                    SqlCommand cmd = new SqlCommand(query, this.connection);

                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.PhoneNumber = dr.GetString(2);
                            employeeModel.Address = dr.GetString(3);
                            employeeModel.Department = dr.GetString(4);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(5));
                            employeeModel.BasicPay = dr.GetDouble(6);
                            employeeModel.Deductions = dr.GetDouble(7);
                            employeeModel.TaxablePay = dr.GetDouble(8);
                            employeeModel.Tax = dr.GetDouble(9);
                            employeeModel.NetPay = dr.GetDouble(10);
                            employeeModel.StartDate = dr.GetDateTime(11);
                            employeeModel.City = dr.GetString(12);
                            employeeModel.Country = dr.GetString(13);

                            Console.WriteLine("{0} {1} {2} {3}  ", employeeModel.EmployeeID, employeeModel.EmployeeName, employeeModel.PhoneNumber, employeeModel.Address);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data Not Found");
                    }
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public void UpdateSalaryQuery()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)

                {
                    //sqlConnection.Open();
                    string query = "update employee set BasicPay=3000000 where EmployeeName= 'Bruce wayne'";
                    this.connection.Open();
                    //Pass query to TSql
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Updated!");
                    }
                    else
                    {
                        Console.WriteLine("Not Updated!");
                    }
                    //Close Connection
                    this.connection.Close();
                    GetAllEmployee();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }


    }
}
