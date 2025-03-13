using Student_Management_System.Models;

namespace Student_Management_System.Repositories
{
    public interface IEnrollmentRepository : IRepository<Enrollment>
    {
        Task<IEnumerable<Enrollment>> GetCourseEnrollmentsAsync(int courseId);
    }
}
