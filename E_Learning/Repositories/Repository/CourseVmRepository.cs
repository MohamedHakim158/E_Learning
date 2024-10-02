using E_Learning.Models;
using E_Learning.Repositories.IReposatories;
using E_Learning.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repositories.Repository
{
    public class CourseVmRepository : ICourseViewModelRepository
    {
        private readonly ApplicationDbContext context;
        
        public CourseVmRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<CourseViewModel>> GetBestSellerCourses()
        {
            var courses = await context.CourseViewModels.Where(p=> p.numOfStudents > 1000).OrderBy(p=>p.numOfStudents).ToListAsync();
            return courses;
        }

        public async Task<List<CourseViewModel>> GetCourseViewModels()
        {
            return await context.CourseViewModels.ToListAsync();
        }

        public async Task<List<CourseViewModel>> GetCourseViewModelsForsubcategory(string subCategoryId)
        {
            return await context.CourseViewModels.Where(C => C.SubCategoryId == subCategoryId).ToListAsync();
        }

        public async Task<List<CourseViewModel>> GetPendingCourses()
        {
            var courses = await context.CourseViewModels.Where(p => p.Status == "Pending").ToListAsync();
            return courses;
        }
        public async Task<List<CourseViewModel>> GetTopRatedCourses()
        {
            var courses = await context.CourseViewModels.Where(p => p.Review > 4.5).ToListAsync();
            return courses;
        }
    }
}
