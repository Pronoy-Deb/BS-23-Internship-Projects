using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title must be between 1 - 100")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        public ICollection<Enrollment> Enrollments { get; set; } = [];
    }
}
