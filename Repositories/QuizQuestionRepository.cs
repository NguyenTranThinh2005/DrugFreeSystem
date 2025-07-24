using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DataAccessLayer;
using Repositories.Interface.QuizRepo;

namespace Repositories
{
    public class QuizQuestionRepository : IQuizQuestionRepository
    {
        private readonly DrugFreeSystemDbContext _context;

        public QuizQuestionRepository(DrugFreeSystemDbContext context)
        {
            _context = context;
        }

        public List<QuizQuestion> GetAll()
        {
            return _context.QuizQuestions.ToList();
        }

        public QuizQuestion? GetById(Guid id)
        {
            return _context.QuizQuestions.FirstOrDefault(q => q.QuestionId == id);
        }

        public QuizQuestion Create(QuizQuestion question)
        {
            _context.QuizQuestions.Add(question);
            _context.SaveChanges();
            return question;
        }

        public bool Update(QuizQuestion question)
        {
            var existing = _context.QuizQuestions.Find(question.QuestionId);
            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(question);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(Guid id)
        {
            var question = _context.QuizQuestions.FirstOrDefault(q => q.QuestionId == id);
            if (question == null)
                return false;

            _context.QuizQuestions.Remove(question);
            _context.SaveChanges();
            return true;
        }
    }
}
