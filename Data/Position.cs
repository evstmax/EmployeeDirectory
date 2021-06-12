using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectory.Data
{
    public class Position
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DisplayName("Salary")]
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        [Range((double)decimal.MinValue, (double)decimal.MaxValue, ErrorMessage = "Please enter valid salary")]
        public decimal Salary { get; set; }

    }
}
