using System.Collections.Generic;

namespace EmployeeDirectory.Data
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Employee> Employees { get; set; }

    }
}
