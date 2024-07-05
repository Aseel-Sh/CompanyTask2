using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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


    }
}
