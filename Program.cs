using Company.GetData;
using Company.Repo;
using Microsoft.Data.SqlClient;

public class Program
{
    public static EmployeeRepo Repo = new EmployeeRepo("data source=.;Initial Catalog=Company;Integrated Security=True;TrustServerCertificate=True");
    public static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        employees = GetEmployeeFromDb();

        foreach (var employee in employees)
        {
            Console.WriteLine($"Id = {employee.Id} , Name = {employee.Name} , Monthly Salary = {employee.MonthlySalary} , DepartementId = {employee.DepartmentId}");
        }

        /*List<Department> departments = new List<Department>();
        departments = GetDepartmentFromDB();*/


        Console.WriteLine("Third highest salary: ");
        GetThirdHighestSalary();

        Console.WriteLine("Employees with Yearly salary greater than 5000: ");
        //GetYearlySalaryGreater();


        Console.WriteLine("Employees whose name start with 'a': ");
        //GetNamestartA();
    }


    void GetNamestartA()
    {
        throw new NotImplementedException();
    }

    void GetYearlySalaryGreater()
    {
        throw new NotImplementedException();
    }
    void GetThirdHighestSalary()
    {
        var query = "SELECT TOP 1 * FROM (SELECT TOP 3 * FROM Employees ORDER BY MonthlySalary DESC) RESULT ORDER BY MonthlySalary";
    }

    private static List<Employee> GetEmployeeFromDb()
    {
        List<Employee> employees = new List<Employee>();
        string connectionString = "data source=.;Initial Catalog=Company;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection connection = new SqlConnection(connectionString);
        var query = "Select * from employees";
        SqlCommand command = new SqlCommand(query, connection);
        connection.Open();
        var result = command.ExecuteReader();
        while (result.Read())
        {
            employees.Add(new Employee
            {
                Id = result.GetInt32(0),
                Name = result.GetString(1),
                MonthlySalary = result.GetDecimal(2),
                DepartmentId = result.GetInt32(3),
            });
        }
        connection.Close();

        return employees;
    }
}