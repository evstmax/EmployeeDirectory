using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.Models
{
    public class CreateDepartmentDTO
    {

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Department Name Is Too Long")]
        public string Name { get; set; }
    }

    public class UpdateDepartmentDTO : CreateDepartmentDTO
    {
        public IList<CreateEmployeeDTO> Employees { get; set; }
    }

    public class DepartmentDTO : CreateDepartmentDTO
    {
        public int Id { get; set; }
        public IList<EmployeeDTO> Employees { get; set; }

    }
}




