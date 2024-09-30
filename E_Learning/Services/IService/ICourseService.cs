using E_Learning.ViewModels;

namespace E_Learning.Services.IService
{
    public interface ICourseService
    {
        Task<List<CourseViewModel>> GetAllCourses();
        Task<List<CourseViewModel>> GetCoursesWithSubCategory(string subCategoryId);
        //Task<List<CourseViewModel>> AddFilterCoursewithRating(int minRating , string subCategoryId);
        //Task<List<CourseViewModel>> AddFilterCourseWithDuration (int minDuration , int maxDuration ,string subCategoryId);
        //Task<List<CourseViewModel>> AddFilterCourseWithLanguage(string language , string subCategoryId);
        //Task<List<CourseViewModel>> AddFilterCourseWithLevel(string level , string subCategoryId);
        //Task<List<CourseViewModel>> AddFilterCourseWithPrice(int minPrice, int MaxPrice,string subcategoryId );
    }
}
