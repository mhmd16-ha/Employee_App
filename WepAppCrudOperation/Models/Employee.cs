using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WepAppCrudOperation.Models
{
    [Table("Employees",Schema ="HR")]
    public class Employee
    {
        [Key]
        [Display(Name="Id")]
        public int? EmployeeID { get; set; }
        [Display(Name= "Employee Name")]
        [Column(TypeName="VarChar(200)")]
        public string EmployeeName { get; set; } = String.Empty;
        [Display(Name="User Image")]
        [Column(TypeName= "VarChar(200)")]
        public string? ImageUser { get; set; }
        [Display(Name ="Birth Date")]
         [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name ="Salary")]
        [Column(TypeName = "decimal(12)")]
        public decimal Salary { get; set; }
        [Display(Name ="Hiring Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        public DateTime HiringDate { get; set; }
        [Required]
        [Display(Name = "National ID")]
        [MaxLength(14)]
        [MinLength(14)]
        [Column(TypeName = "VarChar(14)")]
        public string NationalID { get; set; } = "";
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

    }
}
