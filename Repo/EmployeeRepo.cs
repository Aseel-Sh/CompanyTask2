using Company.GetData;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repo
{
    public class EmployeeRepo
    {
        SqlConnection connection;
        SqlCommand command;
        public EmployeeRepo(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand(null, connection);
        }

        public void GetThirdHighestSal()
        {
            connection.Open();
            var query = "SELECT TOP 1 * FROM (SELECT TOP 3 * FROM Employees ORDER BY MonthlySalary DESC) RESULT ORDER BY MonthlySalary";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader result = command.ExecuteReader();

            PrintEmployeeData(result);

            connection.Close();
        }

        public void GetYearlySalaryGreater()
        {
            connection.Open();
            var query = "SELECT * FROM Employees WHERE MonthlySalary * 12 > 5000";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader result = command.ExecuteReader();

            PrintEmployeeData(result);

            connection.Close();

        }

        public void GetNamestartA()
        {
            connection.Open();
            var query = "SELECT * FROM Employees WHERE Name LIKE 'a%' ";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader result = command.ExecuteReader();

            PrintEmployeeData(result);

            connection.Close();
        }

        public void GetEmployeeFromDb()
        {
            connection.Open();
            var query = "Select * from employees";
            SqlCommand command = new SqlCommand(query, connection);
            var result = command.ExecuteReader();

            PrintEmployeeData(result);

        }

        private void PrintEmployeeData(SqlDataReader result)
        {
            while (result.Read())
            {
                var Id = result.GetInt32(0);
                var Name = result.GetString(1);
                var MonthlySalary = result.GetDecimal(2);
                var DepartmentId = result.GetInt32(3);

                Console.WriteLine("Id = {0} , Name = {1} , Monthly Salary = {2} , Dept Id = {3}", Id, Name, MonthlySalary, DepartmentId);
            }
        }

        private void ExcecuteQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
        }
    }
}
