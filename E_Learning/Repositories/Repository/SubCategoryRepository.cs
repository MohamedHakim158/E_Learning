using E_Learning.Models;
using E_Learning.Repository.IReposatories;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repositories.Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly DbContext _context;

        public SubCategoryRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubCategory>> GetAllAsync()
        {
            return await _context.Set<SubCategory>()
                .Include(sc => sc.Courses) // Include related courses
                .ToListAsync();
        }

        public async Task<SubCategory> GetByIdAsync(string id)
        {
            return await _context.Set<SubCategory>()
                .Include(sc => sc.Courses) // Include related courses
                .FirstOrDefaultAsync(sc => sc.Id == id);
        }

        public async Task AddAsync(SubCategory subCategory)
        {
            await _context.Set<SubCategory>().AddAsync(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubCategory subCategory)
        {
            _context.Set<SubCategory>().Update(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var subCategory = await _context.Set<SubCategory>().FindAsync(id);
            if (subCategory != null)
            {
                _context.Set<SubCategory>().Remove(subCategory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryIdAsync(string categoryId)
        {
            return await _context.Set<SubCategory>()
                .Where(sc => sc.CategoryId == categoryId)
                .Include(sc => sc.Courses) // Include related courses
                .ToListAsync();
        }

       
    }

}
