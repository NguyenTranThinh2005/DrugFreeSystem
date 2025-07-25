using BusinessObjects;
using System;
using System.Collections.Generic;

namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface IUserSurveyResponseService
    {
        List<UserSurveyResponse> GetAll();
        UserSurveyResponse? GetById(int id);
        string Add(UserSurveyResponse userSurveyResponse);
        bool Update(UserSurveyResponse userSurveyResponse);
        bool Delete(int id);

    }
}
