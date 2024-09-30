using E_Learning.Areas.Home.Models;

namespace E_Learning.Areas.Home.Data
{
    public interface ICourseCardService
    {
        public IEnumerable<CourseCardDetails> getAll();
        public CourseCardDetails getCourse(string id);
    }
}
