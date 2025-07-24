using BusinessObjects;


namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface ISurveyOptionService
    {
        List<SurveyOption> GetAll();
        SurveyOption? GetById(Guid id);
        void Add(SurveyOption option);
        bool Update(SurveyOption option);
        bool Delete(Guid id);
        List<SurveyOption> GetByQuestionId(Guid questionId);
    }
} 