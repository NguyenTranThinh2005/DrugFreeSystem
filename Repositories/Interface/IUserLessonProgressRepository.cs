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
        UserLessonProgress? GetUserLessonProgressById(int progressId);
        List<UserLessonProgress> GetUserLessonProgressByUserId(int userId);
        List<UserLessonProgress> GetUserLessonProgressByLessonId(int lessonId);
        UserLessonProgress AddUserLessonProgress(UserLessonProgress userLessonProgress);
        UserLessonProgress UpdateUserLessonProgress(UserLessonProgress userLessonProgress);
        bool DeleteUserLessonProgress(int progressId);
        List<UserLessonProgress> GetUserLessonProgressByUserIdAndCourseId(int userId, int courseId);
        List<UserLessonProgress> GetAllUserLessonProgressesByUserId(int userId);
        UserLessonProgress? GetUserLessonProgressByUserIdAndLessonId(int userId, int lessonId);
        int CountCompletedLessonsForUserInCourse(int userId, int courseId);
    }
}

