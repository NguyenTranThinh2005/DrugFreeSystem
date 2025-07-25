using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface.QuizRepo;

namespace Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly DrugPreventSystemContext _context;

        public QuizRepository(DrugPreventSystemContext context)
        {
            _context = context;
        }

        public List<Quiz> GetAll()
        {
            return _context.Quizzes.ToList();
        }

        public Quiz? GetById(int id)
        {
            return _context.Quizzes
                .Include(q => q.QuizQuestions.OrderBy(qq => qq.Sequence))
                    .ThenInclude(qq => qq.QuizOptions)
                .FirstOrDefault(q => q.QuizId == id);
        }

        public Quiz Create(Quiz quiz)
        {
            _context.Quizzes.Add(quiz);
            _context.SaveChanges();
            return quiz;
        }

        public bool Update(Quiz quiz)
        {
            var existing = _context.Quizzes.Find(quiz.QuizId);
            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(quiz);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var quiz = _context.Quizzes.FirstOrDefault(q => q.QuizId == id);
            if (quiz == null)
                return false;

            _context.Quizzes.Remove(quiz);
            _context.SaveChanges();
            return true;
        }

        public Quiz? GetQuizByLessonId(int lessonId)
        {
            return _context.Quizzes
                .Where(q => q.LessonId == lessonId)
                .Include(q => q.QuizQuestions.OrderBy(qq => qq.Sequence))
                    .ThenInclude(qq => qq.QuizOptions)
                .FirstOrDefault();
        }

        public Quiz? GetQuizWithQuestionsAndOptionsByLessonId(int lessonId)
        {
            return _context.Quizzes
                .Include(q => q.QuizQuestions.OrderBy(qq => qq.Sequence))
                    .ThenInclude(qq => qq.QuizOptions)
                .FirstOrDefault(q => q.LessonId == lessonId);
        }
    }
}
