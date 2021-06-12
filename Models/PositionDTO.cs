using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDirectory.Models
{
    public class CreatePositionDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Position Name Is Too Long")]
        public string Name { get; set; }

        [DisplayName("Salary")]
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        [Range((double)decimal.MinValue, (double)decimal.MaxValue, ErrorMessage = "Please enter valid salary")]
        public decimal Salary { get; set; }
    }

    public class UpdatePositionDTO : CreatePositionDTO
    {
               public IList<CreateEmployeeDTO> Employees { get; set; }
    }

    public class PositionDTO : CreatePositionDTO
    {
        public int Id { get; set; }
        public IList<EmployeeDTO> Employees { get; set; }

    }










}




