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
        UserSurveyResponse? GetById(Guid id);
        bool Update(UserSurveyResponse response);
        bool Delete(Guid id);
        UserSurveyResponse? GetByIdWithAnswers(Guid id);
        UserSurveyResponse? GetByIdWithAnswersAndSurvey(Guid responseId);
        List<UserSurveyResponse> GetByUserIdWithSurvey(Guid userId);

    }
}
