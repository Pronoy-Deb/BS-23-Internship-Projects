using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name must be between 1 - 100")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public StudentProfile? Profile { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = [];
    }
}
