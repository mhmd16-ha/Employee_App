using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WepAppCrudOperation.Models
{
    [Table("Departments",Schema="HR")]
    public class Department
    {
        [Key]
        [Display(Name = "ID")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name ="DepartMent Name")]
        [Column(TypeName="VarChar(200)")]
        public string DepartmentName { get; set; } = String.Empty;

    }
}
