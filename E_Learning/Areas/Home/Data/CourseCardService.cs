using E_Learning.Repository.IReposatories;
using E_Learning.Areas.Home.Models;
using E_Learning.Models;

namespace E_Learning.Areas.Home.Data
{
    public class CourseCardService:ICourseCardService
    {
        private readonly ICourseRepository _course;
        

        public CourseCardService(ICourseRepository course  )
        {
            _course = course;
        }

        public CourseCardDetails getCourse(string id)
        {
            CourseCardDetails details = new CourseCardDetails();
            var course = _course.GetByIdAsync(id);

            details.Id = id;
            details.NumberOfRegisters = course.Result.NumberOfRegisters;
            details.Title = course.Result.Title;
            details.Description = course.Result.Description;
            details.Price = course.Result.Price;
            details.Image = course.Result.Image;
            details.netPrice = course.Result.Price - course.Result.Price*0.2;

            return details;
        }

        public IEnumerable<CourseCardDetails> getAll() 
        { 
            var IDS = _course.GetAllAsync().Result.Select(c => c.Id).ToList();

            List<CourseCardDetails> c = new List<CourseCardDetails>();
            foreach (var id in IDS) 
            { 
                c.Add(getCourse(id));
            }

            return c;
        }


    }
}
