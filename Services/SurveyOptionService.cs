using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using Repositories.Interface.SurveyRepo;
using System;
using System.Collections.Generic;

namespace DrugPreventionSystem.BusinessLogic.Services
{
    public class SurveyOptionService : ISurveyOptionService
    {
        private readonly ISurveyOptionRepository _surveyOptionRepository;

        public SurveyOptionService(ISurveyOptionRepository surveyOptionRepository)
        {
            _surveyOptionRepository = surveyOptionRepository;
        }

        public List<SurveyOption> GetAll()
        {
            return _surveyOptionRepository.GetAll();
        }

        public SurveyOption? GetById(int id)
        {
            return _surveyOptionRepository.GetById(id);
        }

        public void Add(SurveyOption option)
        {
            _surveyOptionRepository.Create(option);
        }

        public bool Update(SurveyOption option)
        {
            return _surveyOptionRepository.Update(option);
        }

        public bool Delete(int id)
        {
            return _surveyOptionRepository.Delete(id);
        }

        public List<SurveyOption> GetByQuestionId(int questionId)
        {
            return _surveyOptionRepository.GetByQuestionId(questionId);
        }
    }
}
