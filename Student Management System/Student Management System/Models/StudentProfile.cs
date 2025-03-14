using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class StudentProfile
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bio must be between 1 - 100")]
        [MaxLength(100)]
        public string Bio { get; set; } = string.Empty;
        public Student? Student { get; set; }
    }
}
