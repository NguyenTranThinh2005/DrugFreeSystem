using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace Repositories.Interface.UserRepo
{
    public interface IUserLessonProgressRepository
    {
        List<UserLessonProgress> GetUserLessonProgresses();
        UserLessonProgress? GetUserLessonProgressById(Guid progressId);
        List<UserLessonProgress> GetUserLessonProgressByUserId(Guid userId);
        List<UserLessonProgress> GetUserLessonProgressByLessonId(Guid lessonId);
        UserLessonProgress AddUserLessonProgress(UserLessonProgress userLessonProgress);
        UserLessonProgress UpdateUserLessonProgress(UserLessonProgress userLessonProgress);
        bool DeleteUserLessonProgress(Guid progressId);
        List<UserLessonProgress> GetUserLessonProgressByUserIdAndCourseId(Guid userId, Guid courseId);
        List<UserLessonProgress> GetAllUserLessonProgressesByUserId(Guid userId);
        UserLessonProgress? GetUserLessonProgressByUserIdAndLessonId(Guid userId, Guid lessonId);
        int CountCompletedLessonsForUserInCourse(Guid userId, Guid courseId);
    }
}

