using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface ISurveyService
    {
        void Add(Survey survey);
        List<Survey> GetAll();
        Survey GetById(Guid id);
        bool Delete(Guid id);
        bool Update(Survey survey);
        List<SurveyQuestion> GetSurveyQuestionsWithAllDetails(Guid surveyId);
    }
}
