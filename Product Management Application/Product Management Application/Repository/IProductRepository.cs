using Microsoft.EntityFrameworkCore;
using Product_Management_Application.Data;

namespace Product_Management_Application.Repository
{
    public interface IProductRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }

    public class Repository<T> : IProductRepository<T> where T : class
    {
        protected readonly ProductDbContext _context;
        protected readonly DbSet<T> _dbSet;

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Repository(ProductDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }
    }

}
