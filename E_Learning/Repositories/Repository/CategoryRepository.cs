using E_Learning.Models;
using E_Learning.Repository.IReposatories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.Repositories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext _context;

        public CategoryRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Set<Category>().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(string id)
        {
            return await _context.Set<Category>().FindAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            await _context.Set<Category>().AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Set<Category>().Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var category = await _context.Set<Category>().FindAsync(id);
            if (category != null)
            {
                _context.Set<Category>().Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Category> GetCategoryWithSubCategoriesAsync(string categoryId)
        {
            return await _context.Set<Category>()
                .Include(c => c.SubCategories)
                .FirstOrDefaultAsync(c => c.Id == categoryId);
        }

  
    }

}
