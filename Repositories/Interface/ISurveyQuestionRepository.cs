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
        SurveyQuestion? GetSurveyQuestionById(int id);
        List<SurveyQuestion> GetSurveyQuestionsBySurveyId(int surveyId);
        SurveyQuestion AddSurveyQuestion(SurveyQuestion question);
        bool UpdateSurveyQuestion(SurveyQuestion question);
        bool DeleteSurveyQuestion(int id);
        List<SurveyQuestion> GetSurveyQuestionsWithAllDetailsBySurveyId(int surveyId);
    }
}
