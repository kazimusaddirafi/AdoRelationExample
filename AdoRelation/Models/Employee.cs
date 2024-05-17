using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoRelation.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter employee name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter your pin")]
        public string Pin { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }

    }
}
