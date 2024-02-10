using System.ComponentModel.DataAnnotations;

namespace Employee_Management_App.Models
{
    public class Department
    {

        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
    }
}
