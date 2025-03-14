using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Enrollment
    {
        [Key]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        [Key]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
