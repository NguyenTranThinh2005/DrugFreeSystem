using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface.UserRepo;

namespace Repositories
{
    public class UserQuizAnswerRepository : IUserQuizAnswerRepository
    {
        private readonly DrugFreeSystemDbContext _context;

        public UserQuizAnswerRepository(DrugFreeSystemDbContext context)
        {
            _context = context;
        }

        public UserQuizAnswer AddUserQuizAnswer(UserQuizAnswer userQuizAnswer)
        {
            _context.UserQuizAnswers.Add(userQuizAnswer);
            _context.SaveChanges();
            return userQuizAnswer;
        }

        public bool DeleteUserQuizAnswer(Guid userQuizAnswerId)
        {
            var item = _context.UserQuizAnswers
                .FirstOrDefault(qa => qa.UserQuizAnswerId == userQuizAnswerId);

            if (item != null)
            {
                _context.UserQuizAnswers.Remove(item);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public UserQuizAnswer? GetUserQuizAnswerById(Guid userQuizAnswerId)
        {
            return _context.UserQuizAnswers
                .FirstOrDefault(qa => qa.UserQuizAnswerId == userQuizAnswerId);
        }

        public List<UserQuizAnswer> GetUserQuizAnswers()
        {
            return _context.UserQuizAnswers.ToList();
        }

        public List<UserQuizAnswer> GetUserQuizAnswersByUserId(Guid userId)
        {
            return _context.UserQuizAnswers
                .Where(qa => qa.UserId == userId)
                .ToList();
        }

        public List<UserQuizAnswer> GetUserQuizAnswersByQuestionId(Guid questionId)
        {
            return _context.UserQuizAnswers
                .Where(qa => qa.QuestionId == questionId)
                .ToList();
        }

        public List<UserQuizAnswer> GetUserQuizAnswersByUserIdAndQuizId(Guid userId, Guid quizId)
        {
            return _context.UserQuizAnswers
                .Include(qa => qa.Question)
                .Where(qa => qa.UserId == userId && qa.Question.QuizId == quizId)
                .ToList();
        }

        public List<UserQuizAnswer> GetUserQuizAnswersForQuizAttempt(Guid userId, Guid quizId, DateTime takenAt)
        {
            return _context.UserQuizAnswers
                .Include(qa => qa.Question)
                .Where(qa => qa.UserId == userId &&
                             qa.Question.QuizId == quizId &&
                             qa.AnsweredAt == takenAt)
                .ToList();
        }

        public UserQuizAnswer UpdateUserQuizAnswer(UserQuizAnswer userQuizAnswer)
        {
            _context.UserQuizAnswers.Update(userQuizAnswer);
            _context.SaveChanges();
            return userQuizAnswer;
        }
    }
}
