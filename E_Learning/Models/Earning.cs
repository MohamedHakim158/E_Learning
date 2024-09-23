using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.Models
{
    public class Earning
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Balance { get; set; }
        [ForeignKey("User")]
        public  string UserId { get; set; }
        public User User { get; set; }
    }
}
