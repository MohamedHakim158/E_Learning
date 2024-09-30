using E_Learning.ViewModels;

namespace E_Learning.Repositories.IReposatories
{
    public interface ICourseViewModelRepository
    {
        Task<List<CourseViewModel>> GetCourseViewModelsForsubcategory(string subCategory);
        Task<List<CourseViewModel>> GetCourseViewModels();
    }
}
