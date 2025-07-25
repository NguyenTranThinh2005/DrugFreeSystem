using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories.Interface.UserRepo
{
    public interface IUserModuleQuizResultRepository
    {
        List<UserModuleQuizResult> GetUserModuleQuizResults();
        UserModuleQuizResult? GetUserModuleQuizResultById(int resultId);
        List<UserModuleQuizResult> GetUserModuleQuizResultsByUserId(int userId);
        List<UserModuleQuizResult> GetUserModuleQuizResultsByLessonId(int lessonId);
        UserModuleQuizResult AddUserModuleQuizResult(UserModuleQuizResult userModuleQuizResult);
        UserModuleQuizResult UpdateUserModuleQuizResult(UserModuleQuizResult userModuleQuizResult);
        bool DeleteUserModuleQuizResult(int resultId);
        UserModuleQuizResult? GetLatestUserModuleQuizResultForLesson(int userId, int lessonId);
    }
}
