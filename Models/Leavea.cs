using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Leave
{ 
    public class Leavea
    {
        [Key]
        public int LeaveId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [StringLength(75)]
        public string? LeaveType { get; set; }
         [StringLength(75)]
        public string? Status { get; set; }
         public string? UserID { get; set; }       
    }
}