﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace E_Learning.Models
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CoursePreview> CoursePreviews { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
        public DbSet<CourseDiscount> CourseDiscounts { get; set; }
        public DbSet<CourseCupons> CourseCupons { get; set; }
        public DbSet<SectionLessons> SectionLessons { get; set; }
        public DbSet<SectionQuiz> SectionQuizzes { get; set; }
        public DbSet<QuizQuestion> quizQuestions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<InstructorWithdraw> InstructorWithdraws { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }   

    }
}
