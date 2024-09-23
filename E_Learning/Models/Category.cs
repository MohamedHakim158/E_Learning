namespace E_Learning.Models
{
    public class Category
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public List<SubCategory>? SubCategories {  get; set; }
    }
}
