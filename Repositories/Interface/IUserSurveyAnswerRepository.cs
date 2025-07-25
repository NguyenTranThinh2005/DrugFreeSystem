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
        UserSurveyAnswer? GetUserSurveyAnswerById(int id);
        List<UserSurveyAnswer> GetUserSurveyAnswerByUserId(int userId);
        void DeleteUserSurveyAnswerById(int id);
        void UpdateUserSurveyAnswer(UserSurveyAnswer userSurveyAnswer);
        List<UserSurveyAnswer> GetUserSurveyAnswerByResponseId(int responseId);
    }
}
