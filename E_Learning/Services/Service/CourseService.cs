using E_Learning.Repositories.IReposatories;
using E_Learning.Repository.IReposatories;
using E_Learning.Services.IService;
using E_Learning.ViewModels;

namespace E_Learning.Services.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseViewModelRepository courseView;

        public CourseService(ICourseViewModelRepository courseView)
        {
            this.courseView = courseView;
        }
        public async Task<List<CourseViewModel>> GetAllCourses()
        {
            return await courseView.GetCourseViewModels();
        }

        public async Task<List<CourseViewModel>> GetCoursesWithSubCategory(string subCategoryId)
        {
            return await courseView.GetCourseViewModelsForsubcategory(subCategoryId);
        }

    }
}
