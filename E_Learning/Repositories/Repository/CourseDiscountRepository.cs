using E_Learning.Models;
using E_Learning.Repository.IReposatories;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repositories.Repository
{
    public class CourseDiscountRepository : ICourseDiscountRepository
    {
        private readonly DbContext _context;

        public CourseDiscountRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseDiscount>> GetAllAsync()
        {
            return await _context.Set<CourseDiscount>().ToListAsync();
        }

        public async Task<CourseDiscount> GetByIdAsync(string id)
        {
            return await _context.Set<CourseDiscount>().FindAsync(id);
        }

        public async Task AddAsync(CourseDiscount courseDiscount)
        {
            await _context.Set<CourseDiscount>().AddAsync(courseDiscount);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CourseDiscount courseDiscount)
        {
            _context.Set<CourseDiscount>().Update(courseDiscount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var courseDiscount = await _context.Set<CourseDiscount>().FindAsync(id);
            if (courseDiscount != null)
            {
                _context.Set<CourseDiscount>().Remove(courseDiscount);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CourseDiscount>> GetDiscountsByCourseIdAsync(string courseId)
        {
            return await _context.Set<CourseDiscount>()
                .Where(cd => cd.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<CourseDiscount>> GetActiveDiscountsAsync()
        {
            return await _context.Set<CourseDiscount>()
                .Where(cd => cd.ExpireDate > DateTime.Now)
                .ToListAsync();
        }
    }

}
