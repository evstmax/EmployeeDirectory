using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeDirectory.Data;

namespace EmployeeDirectory.Models
{
    public class CreateEmployeeDTO
    {
//        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Patronymic { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "EmploymentDate")]
        public DateTime EmploymentDate { get; set; }


        public int PositionId { get; set; }

        public int DepartmentId { get; set; }



        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "The phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }



    }

    public class UpdateEmployeeDTO : CreateEmployeeDTO
    {

    }

    public class EmployeeDTO : CreateEmployeeDTO
    {
        public int Id { get; set; }
        public PositionDTO Position { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
