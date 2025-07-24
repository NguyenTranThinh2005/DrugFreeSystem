

using BusinessObjects;

namespace Repositories.Interface.SurveyRepo
{
    public interface ISurveyOptionRepository
    {
        List<SurveyOption> GetAll();
        SurveyOption? GetById(Guid id);
        SurveyOption Create(SurveyOption surveyOption);
        bool Update(SurveyOption surveyOption);
        bool Delete(Guid id);
        List<SurveyOption> GetByQuestionId(Guid questionId);
    }
} 