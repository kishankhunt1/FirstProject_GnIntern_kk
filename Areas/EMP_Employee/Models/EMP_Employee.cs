using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstProject.Areas.EMP_Employee.Models
{

    public class EMP_EmployeeModel
    {
        public int? EmployeeID { get; set; }
        [Required]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }
        [Required]
        [DisplayName("Email")]
        public string EmployeeEmail { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Mobile Number must be 10 character")]
        public string MobileNo { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Salary { get; set; }
        [Required]
        [DisplayName("Department")]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string? Address { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public HobbyDropDown Hobby { get; set; }

    }

    public class HobbyDropDown
    {
        public int HobbyID { get; set; }
        public string HobbyName { get; set; }
    }

    public class EmployeeCount
    {
        public string Month { get; set; }
        public int CountOfEmployee { get; set; }
    }



}
