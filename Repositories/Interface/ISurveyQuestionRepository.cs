using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace Repositories.Interface.SurveyRepo
{
    public interface ISurveyQuestionRepository
    {
        List<SurveyQuestion> GetAllSurveyQuestions();
        SurveyQuestion? GetSurveyQuestionById(Guid id);
        List<SurveyQuestion> GetSurveyQuestionsBySurveyId(Guid surveyId);
        SurveyQuestion AddSurveyQuestion(SurveyQuestion question);
        bool UpdateSurveyQuestion(SurveyQuestion question);
        bool DeleteSurveyQuestion(Guid id);
        List<SurveyQuestion> GetSurveyQuestionsWithAllDetailsBySurveyId(Guid surveyId);
    }
}
