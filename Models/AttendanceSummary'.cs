using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management_App.Models
{
    public class AttendanceSummary
    {

        [Key]
        public int AttendanceSummaryId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
    }
}
