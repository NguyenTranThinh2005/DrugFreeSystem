using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace Repositories.Interface.UserRepo
{
    public interface IUserSurveyAnswerRepository
    {
        UserSurveyAnswer AddNewUserSurveyAnswer(UserSurveyAnswer userSurveyAnswer);
        List<UserSurveyAnswer> GetAllUserSurveyAnswers();
        UserSurveyAnswer? GetUserSurveyAnswerById(Guid id);
        List<UserSurveyAnswer> GetUserSurveyAnswerByUserId(Guid userId);
        void DeleteUserSurveyAnswerById(Guid id);
        void UpdateUserSurveyAnswer(UserSurveyAnswer userSurveyAnswer);
        List<UserSurveyAnswer> GetUserSurveyAnswerByResponseId(Guid responseId);
    }
}
