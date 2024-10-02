using E_Learning.Models;
using E_Learning.ViewModels;

namespace E_Learning.Services.IService
{
    public interface IAdminService
    {
        public Task<List<User>> ShowAdmins();
        public Task<ProcessResult> AddAdmin(string userName);
        public Task<ProcessResult> DeleteAdmin(string adminId);
        public Task<List<CourseViewModel>> ShowPendingCourses();  // Displays all courses that needs admin approval to publish
        public Task RejectCourse(string CourseId);
        public Task AdmitCourse(string CourseId);
        public Task<List<CourseViewModel>> ShowCourseBestSeller(); // shows courses with highest enrollment rates , I suppose here to be more than 1K enrollments for course
        public Task<List<CourseViewModel>> GetTopRatedCourses();
        public Task<IEnumerable<Enrollment>> TrackUserEnrollment();
        public Task<IEnumerable<Enrollment>> TrackCourseEnrollments(string courseId);
        public Task<IEnumerable<Enrollment>> TrackUserEnrollments(string UserId); 
        public Task<IEnumerable<InstructorWithdraw>> ShowInstructorsWithdraws();
        public Task<IEnumerable<InstructorWithdraw>> TrackInstructorWithdrawHistory(string instructorId);
    }
}
