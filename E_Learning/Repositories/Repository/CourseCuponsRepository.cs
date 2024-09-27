using E_Learning.Models;
using E_Learning.Repository.IReposatories;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repositories.Repository
{
    public class CourseCuponsRepository : ICourseCuponsRepository
    {
        private readonly DbContext _context;

        public CourseCuponsRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseCupons>> GetAllAsync()
        {
            return await _context.Set<CourseCupons>().ToListAsync();
        }

        public async Task<CourseCupons> GetByIdAsync(string id)
        {
            return await _context.Set<CourseCupons>().FindAsync(id);
        }

        public async Task AddAsync(CourseCupons courseCupon)
        {
            await _context.Set<CourseCupons>().AddAsync(courseCupon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CourseCupons courseCupon)
        {
            _context.Set<CourseCupons>().Update(courseCupon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var courseCupon = await _context.Set<CourseCupons>().FindAsync(id);
            if (courseCupon != null)
            {
                _context.Set<CourseCupons>().Remove(courseCupon);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CourseCupons> GetByCodeAsync(string code)
        {
            return await _context.Set<CourseCupons>()
                .FirstOrDefaultAsync(c => c.Code == code);
        }

        public async Task<IEnumerable<CourseCupons>> GetActiveCouponsAsync()
        {
            return await _context.Set<CourseCupons>()
                .Where(c => c.ExpireDate > DateTime.Now && c.UsageLimit > c.NumberOfUsages)
                .ToListAsync();
        }
    }


}
