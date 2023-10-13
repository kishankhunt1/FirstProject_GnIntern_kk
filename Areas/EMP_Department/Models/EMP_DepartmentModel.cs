using System.ComponentModel.DataAnnotations;

namespace FirstProject.Areas.EMP_Department.Models
{
    public class EMP_DepartmentModel
    {
        public int? DepartmentID { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public class DepartmentDropDown
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}
