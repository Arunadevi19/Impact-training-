using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Leave
{ 

    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
         [StringLength(75)]
        public string? FirstName { get; set; }
         [StringLength(75)]
        public string? LastName { get; set; }
        [Required(ErrorMessage ="Please enter user ID")]
        [DataType(DataType.Password)]
        [StringLength(30)]
         public string? Password { get; set; }
        [Required(ErrorMessage ="Please enter user ID")]

        [StringLength(30)]
        public string? UserID { get; set; }

        public string? IsAdmin { get; set; }

        public ICollection<Leavea> Leavea { get; set; } = new List<Leavea>();
    }
}