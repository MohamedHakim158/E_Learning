using E_Learning.Models;
using E_Learning.Repository.IReposatories;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.Repositories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        
        public async Task AddAsync(Category entity)
        {
            await context.Categories.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(int id)
        {
            await context.SaveChangesAsync();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
