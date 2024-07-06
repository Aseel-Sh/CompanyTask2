using Company.GetData;
using Company.Repo;
using Microsoft.Data.SqlClient;

public class Program
{
    public static EmployeeRepo Repo = new EmployeeRepo("data source=.;Initial Catalog=Company;Integrated Security=True;TrustServerCertificate=True");
    public static void Main(string[] args)
    {
/*        Console.WriteLine("-----------------------------------------------------------------------------");
        Repo.GetEmployeeFromDb();
        Console.WriteLine("-----------------------------------------------------------------------------");*/
         
        Console.WriteLine("Third highest salary: ");
        Repo.GetThirdHighestSal();

        Console.WriteLine("-----------------------------------------------------------------------------");

        Console.WriteLine("Employees with Yearly salary greater than 5000: ");
        Repo.GetYearlySalaryGreater();

        Console.WriteLine("-----------------------------------------------------------------------------");

        Console.WriteLine("Employees whose name start with 'a': ");
        Repo.GetNamestartA();

        Console.WriteLine("-----------------------------------------------------------------------------");
    }



}