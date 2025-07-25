using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace Repositories.Interface.UserRepo
{
    public interface IUserSurveyResponseRepository
    {
        UserSurveyResponse Create(UserSurveyResponse response);
        List<UserSurveyResponse> GetAll();
        UserSurveyResponse? GetById(int id);
        bool Update(UserSurveyResponse response);
        bool Delete(int id);
        UserSurveyResponse? GetByIdWithAnswers(int id);
        UserSurveyResponse? GetByIdWithAnswersAndSurvey(int responseId);
        List<UserSurveyResponse> GetByUserIdWithSurvey(int userId);

    }
}
