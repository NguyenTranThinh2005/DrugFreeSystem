using BusinessObjects;
using System;
using System.Collections.Generic;

namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface IUserSurveyAnswerService
    {
        List<UserSurveyAnswer> GetAll();
        UserSurveyAnswer? GetById(Guid id);
        List<UserSurveyAnswer> GetByUserId(Guid userId);
        string Add(UserSurveyAnswer userSurveyAnswer);
        bool Update(UserSurveyAnswer userSurveyAnswer);
        bool Delete(Guid id);
    }
}
