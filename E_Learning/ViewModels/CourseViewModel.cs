namespace E_Learning.ViewModels
{
    public class CourseViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string InstructorName { get; set; }
        public string Status {  get; set; }
        public double Review { get; set; }
        public string SubCategoryId { get; set; }
        public double totalHours { get; set; }
        public string NumOfLessons { get; set; }
        public string level { get; set; }
        public int numOfStudents { get; set; }
        public string CourseImage { get; set; }
        public int NumOfResults { get; set; }



        public CourseViewModel()
        {

        }
    }

}
