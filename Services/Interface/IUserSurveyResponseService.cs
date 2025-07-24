using BusinessObjects;
using System;
using System.Collections.Generic;

namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface IUserSurveyResponseService
    {
        List<UserSurveyResponse> GetAll();
        UserSurveyResponse? GetById(Guid id);
        string Add(UserSurveyResponse userSurveyResponse);
        bool Update(UserSurveyResponse userSurveyResponse);
        bool Delete(Guid id);

    }
}
