using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface.SurveyRepo;

namespace Repositories
{
    public class SurveyQuestionRepository : ISurveyQuestionRepository
    {
        private readonly DrugFreeSystemDbContext _context;

        public SurveyQuestionRepository(DrugFreeSystemDbContext context)
        {
            _context = context;
        }

        public List<SurveyQuestion> GetAllSurveyQuestions()
        {
            return _context.SurveyQuestions.ToList();
        }

        public SurveyQuestion? GetSurveyQuestionById(Guid id)
        {
            return _context.SurveyQuestions.FirstOrDefault(q => q.QuestionId == id);
        }

        public List<SurveyQuestion> GetSurveyQuestionsBySurveyId(Guid surveyId)
        {
            return _context.SurveyQuestions
                .Where(q => q.SurveyId == surveyId)
                .ToList();
        }

        public SurveyQuestion AddSurveyQuestion(SurveyQuestion question)
        {
            _context.SurveyQuestions.Add(question);
            _context.SaveChanges();
            return question;
        }

        public bool UpdateSurveyQuestion(SurveyQuestion question)
        {
            var existing = _context.SurveyQuestions.Find(question.QuestionId);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(question);
            existing.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteSurveyQuestion(Guid id)
        {
            var question = _context.SurveyQuestions.Find(id);
            if (question == null) return false;

            _context.SurveyQuestions.Remove(question);
            _context.SaveChanges();
            return true;
        }

        public List<SurveyQuestion> GetSurveyQuestionsWithAllDetailsBySurveyId(Guid surveyId)
        {
            return _context.SurveyQuestions
                .Where(q => q.SurveyId == surveyId)
                .Include(q => q.SurveyOptions.OrderBy(o => o.CreatedAt))
                .OrderBy(q => q.Sequence)
                .ToList();
        }
    }
}
