using E_Learning.Models;
namespace E_Learning.Repository.IReposatories
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<Course>> GetCoursesBySubCategoryAsync(string subCategoryId);
        Task<IEnumerable<Course>> GetCoursesByLevelAsync(string courseLevel);
        Task<IEnumerable<Course>> GetCoursesByPriceRangeAsync(double minPrice, double maxPrice);
    }
}
