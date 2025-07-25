

using BusinessObjects;

namespace Repositories.Interface.SurveyRepo
{
    public interface ISurveyOptionRepository
    {
        List<SurveyOption> GetAll();
        SurveyOption? GetById(int id);
        SurveyOption Create(SurveyOption surveyOption);
        bool Update(SurveyOption surveyOption);
        bool Delete(int id);
        List<SurveyOption> GetByQuestionId(int questionId);
    }
} 