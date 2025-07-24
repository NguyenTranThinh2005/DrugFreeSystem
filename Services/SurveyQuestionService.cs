using System;
using System.Collections.Generic;
using System.Linq;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using BusinessObjects;
using Repositories.Interface.SurveyRepo;

namespace DrugPreventionSystem.BusinessLogic.Services
{
    public class SurveyQuestionService : ISurveyQuestionService
    {
        private readonly ISurveyQuestionRepository _surveyQuestionRepository;

        public SurveyQuestionService(ISurveyQuestionRepository surveyQuestionRepository)
        {
            _surveyQuestionRepository = surveyQuestionRepository;
        }

        public void Add(SurveyQuestion question)
        {
            question.QuestionId = Guid.NewGuid();
            question.CreatedAt = DateTime.Now;
            _surveyQuestionRepository.AddSurveyQuestion(question);
        }

        public List<SurveyQuestion> GetAll()
        {
            return _surveyQuestionRepository.GetAllSurveyQuestions();
        }

        public SurveyQuestion GetById(Guid id)
        {
            return _surveyQuestionRepository.GetSurveyQuestionById(id);
        }

        public List<SurveyQuestion> GetBySurveyId(Guid surveyId)
        {
            return _surveyQuestionRepository.GetSurveyQuestionsBySurveyId(surveyId);
        }

        public bool Update(SurveyQuestion question)
        {
            var existing = _surveyQuestionRepository.GetSurveyQuestionById(question.QuestionId);
            if (existing == null) return false;

            existing.QuestionText = question.QuestionText;
            existing.QuestionType = question.QuestionType;
            existing.Sequence = question.Sequence;
            existing.UpdatedAt = DateTime.Now;

            return _surveyQuestionRepository.UpdateSurveyQuestion(existing);
        }

        public bool Delete(Guid id)
        {
            return _surveyQuestionRepository.DeleteSurveyQuestion(id);
        }
    }
}
