using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.Models
{
    public partial class Course
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public  string Description { get; set; }
        public string Language { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CourseLevel { get; set; }
        public int NumberOfRegisters { get; set; } = 0;
        [ForeignKey("SubCategory")]
        public string SubCategoryId {  get; set; }
        public SubCategory  SubCategory  { get; set; }
        public List<CoursePreview>? Previews { get; set; }
        public List<CourseSection> courseSections { get; set; }

    }
}
