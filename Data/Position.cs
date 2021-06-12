using System.Collections.Generic;

namespace EmployeeDirectory.Data
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public virtual IList<Employee> Employees { get; set; }


    }
}
