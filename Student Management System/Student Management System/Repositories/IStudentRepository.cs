using Student_Management_System.Models;

namespace Student_Management_System.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task AddAsync(Student student);
        Task<Student?> GetStudentDetailsByIdAsync(int id);
    }
}
