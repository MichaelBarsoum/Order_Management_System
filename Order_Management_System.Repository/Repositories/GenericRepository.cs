
using Microsoft.EntityFrameworkCore;
using Order_Management_System.CORE.Contexts;
using Order_Management_System.CORE.Contracts;

namespace Order_Management_System.Repositories.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly OrderManagementDbContext _dbContext;
        public GenericRepository(OrderManagementDbContext dbContext) => _dbContext = dbContext;
       
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);
        public async Task CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);        
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        { 
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
