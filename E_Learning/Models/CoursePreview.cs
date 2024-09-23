namespace E_Learning.Models
{    
   public class CoursePreview
   {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public  string Title { get; set; }
        public byte[] Video { get; set; }
        public string CourseId { get; set; }
   }
    
}
