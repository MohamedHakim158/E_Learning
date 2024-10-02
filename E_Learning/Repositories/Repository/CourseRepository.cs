using E_Learning.Models;
using E_Learning.Repository.IReposatories;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repositories.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext context;


        public CourseRepository(ApplicationDbContext  context)

        {
            this.context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await context.Set<Course>().ToListAsync();
        }

        public async Task<Course> GetByIdAsync(string id)
        {
            return await context.Set<Course>().FindAsync(id);
        }

        public async Task AddAsync(Course course)
        {
            await context.Set<Course>().AddAsync(course);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Course old , Course New)
        {
            {
                old.CourseLevel = New.CourseLevel;
                old.Title = New.Title;
                old.Duration = New.Duration;
            }
            context.Set<Course>().Update(old);
            await context.SaveChangesAsync();
        }
        public async Task UpdateCourseStatus(string courseId,string Status)
        {
            var oldCourse = await context.Courses.FirstOrDefaultAsync(p => p.Id == courseId);
            oldCourse!.Status = Status;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var course = await context.Set<Course>().FindAsync(id);
            if (course != null)
            {
                context.Set<Course>().Remove(course);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Course>> GetCoursesBySubCategoryAsync(string subCategoryId)
        {
            return await context.Set<Course>()
                .Where(c => c.SubCategoryId == subCategoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByLevelAsync(string courseLevel)
        {
            return await context.Set<Course>()
                .Where(c => c.CourseLevel == courseLevel)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByPriceRangeAsync(double minPrice, double maxPrice)
        {
            return await context.Set<Course>()
                .Where(c => c.Price  >= minPrice && c.Price <= maxPrice)
                .ToListAsync();
        }
    }

}
