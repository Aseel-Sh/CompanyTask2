using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.GetData
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MonthlySalary { get; set; }
        public int DepartmentId { get; set; } //foreign key. how to make that here?
    }
}
