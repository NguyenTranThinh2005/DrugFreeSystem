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
        UserModuleQuizResult? GetUserModuleQuizResultById(Guid resultId);
        List<UserModuleQuizResult> GetUserModuleQuizResultsByUserId(Guid userId);
        List<UserModuleQuizResult> GetUserModuleQuizResultsByLessonId(Guid lessonId);
        UserModuleQuizResult AddUserModuleQuizResult(UserModuleQuizResult userModuleQuizResult);
        UserModuleQuizResult UpdateUserModuleQuizResult(UserModuleQuizResult userModuleQuizResult);
        bool DeleteUserModuleQuizResult(Guid resultId);
        UserModuleQuizResult? GetLatestUserModuleQuizResultForLesson(Guid userId, Guid lessonId);
    }
}
