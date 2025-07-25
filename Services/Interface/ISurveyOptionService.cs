using BusinessObjects;


namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface ISurveyOptionService
    {
        List<SurveyOption> GetAll();
        SurveyOption? GetById(int id);
        void Add(SurveyOption option);
        bool Update(SurveyOption option);
        bool Delete(int id);
        List<SurveyOption> GetByQuestionId(int questionId);
    }
} 