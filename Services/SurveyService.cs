using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using Repositories.Interface.SurveyRepo;

namespace DrugPreventionSystem.BusinessLogic.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly ISurveyQuestionRepository _surveyQuestionRepository;

        public SurveyService(
            ISurveyRepository surveyRepository,
            ISurveyQuestionRepository surveyQuestionRepository)
        {
            _surveyRepository = surveyRepository;
            _surveyQuestionRepository = surveyQuestionRepository;
        }

        public void Add(Survey survey)
        {
            if (survey == null) return;
            _surveyRepository.AddNewSurvey(survey);
        }

        public List<Survey> GetAll()
        {
            return _surveyRepository.GetAllSurvey();
        }

        public Survey GetById(int id)
        {
            return _surveyRepository.GetSurveyById(id);
        }

        public bool Delete(int id)
        {
            return _surveyRepository.DeleteSurveyById(id);
        }

        public bool Update(Survey survey)
        {
            var existing = _surveyRepository.GetSurveyById(survey.SurveyId);
            if (existing == null) return false;

            existing.Name = survey.Name;
            existing.Description = survey.Description;
            existing.UpdatedAt = DateTime.Now;

            return _surveyRepository.UpdateSurvey(survey);
        }

        public List<SurveyQuestion> GetSurveyQuestionsWithAllDetails(int surveyId)
        {
            return _surveyQuestionRepository.GetSurveyQuestionsWithAllDetailsBySurveyId(surveyId);
        }
    }
}
