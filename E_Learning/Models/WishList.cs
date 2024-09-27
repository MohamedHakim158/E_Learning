﻿using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.Models
{
    public class WishList
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public User User { get; set; }
    }
}
