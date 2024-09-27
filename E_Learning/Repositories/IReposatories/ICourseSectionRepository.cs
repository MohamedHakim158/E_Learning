using E_Learning.Models;

namespace E_Learning.Repository.IReposatories
{
    public interface ICourseSectionRepository : IRepository<CourseSection>
    {
        Task<IEnumerable<CourseSection>> GetSectionsByCourseIdAsync(string courseId);
        
    }

}
