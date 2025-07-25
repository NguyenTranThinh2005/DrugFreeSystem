using BusinessObjects;
using System;
using System.Collections.Generic;

namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface IUserSurveyAnswerService
    {
        List<UserSurveyAnswer> GetAll();
        UserSurveyAnswer? GetById(int id);
        List<UserSurveyAnswer> GetByUserId(int userId);
        string Add(UserSurveyAnswer userSurveyAnswer);
        bool Update(UserSurveyAnswer userSurveyAnswer);
        bool Delete(int id);
    }
}
