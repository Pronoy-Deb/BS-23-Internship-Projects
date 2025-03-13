using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Models;
using System;

namespace Student_Management_System.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context) { }

        public async Task<Student?> GetStudentDetailsByIdAsync(int id)
        {
            return await _dbSet
                .Include(s => s.Profile)
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public override async Task<Student?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(s => s.Profile)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
