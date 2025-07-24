using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface ISurveyQuestionService
    {
        void Add(SurveyQuestion question);
        List<SurveyQuestion> GetAll();
        SurveyQuestion GetById(Guid id);
        List<SurveyQuestion> GetBySurveyId(Guid surveyId);
        bool Update(SurveyQuestion question);
        bool Delete(Guid id);
    }
}
