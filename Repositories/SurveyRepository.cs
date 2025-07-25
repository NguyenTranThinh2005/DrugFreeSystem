using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface.SurveyRepo;

namespace Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly DrugPreventSystemContext _context;

        public SurveyRepository(DrugPreventSystemContext context)
        {
            _context = context;
        }

        public Survey AddNewSurvey(Survey survey)
        {
            _context.Surveys.Add(survey);
            _context.SaveChanges();
            return survey;
        }

        public bool DeleteSurveyById(int id)
        {
            var survey = _context.Surveys.Find(id);
            if (survey == null) return false;

            _context.Surveys.Remove(survey);
            _context.SaveChanges();
            return true;
        }

        public List<Survey> GetAllSurvey()
        {
            return _context.Surveys.ToList();
        }

        public Survey? GetSurveyById(int id)
        {
            return _context.Surveys.FirstOrDefault(s => s.SurveyId == id);
        }

        public Survey? GetSurveyByName(string surveyName)
        {
            return _context.Surveys.FirstOrDefault(s => s.Name == surveyName);
        }

        public bool UpdateSurvey(Survey survey)
        {
            var existing = _context.Surveys.Find(survey.SurveyId);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(survey);
            existing.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return true;
        }
    }
}
