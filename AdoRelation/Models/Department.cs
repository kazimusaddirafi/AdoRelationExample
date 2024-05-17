using System.ComponentModel.DataAnnotations;

namespace AdoRelation.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please provide department name")]
        public string DepartmentName { get; set; }
    }
}
