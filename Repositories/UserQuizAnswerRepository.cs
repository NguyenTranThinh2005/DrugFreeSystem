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
        private readonly DrugPreventSystemContext _context;

        public UserQuizAnswerRepository(DrugPreventSystemContext context)
        {
            _context = context;
        }

        public UserQuizAnswer AddUserQuizAnswer(UserQuizAnswer userQuizAnswer)
        {
            _context.UserQuizAnswers.Add(userQuizAnswer);
            _context.SaveChanges();
            return userQuizAnswer;
        }

        public bool DeleteUserQuizAnswer(int userQuizAnswerId)
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

        public UserQuizAnswer? GetUserQuizAnswerById(int userQuizAnswerId)
        {
            return _context.UserQuizAnswers
                .FirstOrDefault(qa => qa.UserQuizAnswerId == userQuizAnswerId);
        }

        public List<UserQuizAnswer> GetUserQuizAnswers()
        {
            return _context.UserQuizAnswers.ToList();
        }

        public List<UserQuizAnswer> GetUserQuizAnswersByUserId(int userId)
        {
            return _context.UserQuizAnswers
                .Where(qa => qa.UserId == userId)
                .ToList();
        }

        public List<UserQuizAnswer> GetUserQuizAnswersByQuestionId(int questionId)
        {
            return _context.UserQuizAnswers
                .Where(qa => qa.QuestionId == questionId)
                .ToList();
        }

        public List<UserQuizAnswer> GetUserQuizAnswersByUserIdAndQuizId(int userId, int quizId)
        {
            return _context.UserQuizAnswers
                .Include(qa => qa.Question)
                .Where(qa => qa.UserId == userId && qa.Question.QuizId == quizId)
                .ToList();
        }

        public List<UserQuizAnswer> GetUserQuizAnswersForQuizAttempt(int userId, int quizId, DateTime takenAt)
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
