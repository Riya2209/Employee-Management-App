using System.ComponentModel.DataAnnotations;

namespace Employee_Management_App.Models
{
    public class Form
    {
        [Key]
        public int FormId { get; set; }
        public string UserId { get; set; }
        public int Year { get; set; }
        public string FormNumber { get; set; }
    }
}
