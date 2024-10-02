using E_Learning.Repositories.IReposatories;
using E_Learning.Repository.IReposatories;
using E_Learning.Services.IService;
using E_Learning.ViewModels;

namespace E_Learning.Services.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseViewModelRepository courseView;
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseViewModelRepository courseView,ICourseRepository courseRepository)
        {
            this.courseView = courseView;
            this.courseRepository = courseRepository;
        }
        public async Task<List<CourseViewModel>> GetAllCourses()
        {
            return await courseView.GetCourseViewModels();
        }

        public async Task<List<CourseViewModel>> GetCoursesWithSubCategory(string subCategoryId)
        {
            return await courseView.GetCourseViewModelsForsubcategory(subCategoryId);
        }

        public async Task<List<CourseViewModel>> GetPendingCourses()
        {
            var courses = await courseView.GetPendingCourses();
            return courses;
        }
        public async Task UpdateCourseStatus(string CourseId , string Status)
        {
            await courseRepository.UpdateCourseStatus(CourseId, Status);
        }
        public async Task<List<CourseViewModel>> GetTopRatedCourses()
        {
            return await courseView.GetTopRatedCourses();
        }
        public async Task<List<CourseViewModel>> GetBestSeller()
        {
            var courses = await courseView.GetBestSellerCourses();
            return courses;
        }
    }
}
