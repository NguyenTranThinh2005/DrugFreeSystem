using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface.UserRepo;

namespace Repositories
{
    public class UserModuleQuizResultRepository : IUserModuleQuizResultRepository
    {
        private readonly DrugFreeSystemDbContext _context;

        public UserModuleQuizResultRepository(DrugFreeSystemDbContext context)
        {
            _context = context;
        }

        public List<UserModuleQuizResult> GetUserModuleQuizResults()
        {
            return _context.UserModuleQuizResults.ToList();
        }

        public UserModuleQuizResult? GetUserModuleQuizResultById(Guid resultId)
        {
            return _context.UserModuleQuizResults
                           .FirstOrDefault(r => r.ResultId == resultId);
        }

        public List<UserModuleQuizResult> GetUserModuleQuizResultsByUserId(Guid userId)
        {
            return _context.UserModuleQuizResults
                           .Where(r => r.UserId == userId)
                           .ToList();
        }

        public List<UserModuleQuizResult> GetUserModuleQuizResultsByLessonId(Guid lessonId)
        {
            return _context.UserModuleQuizResults
                           .Where(r => r.LessonId == lessonId)
                           .ToList();
        }

        public UserModuleQuizResult? GetLatestUserModuleQuizResultForLesson(Guid userId, Guid lessonId)
        {
            return _context.UserModuleQuizResults
                           .Where(r => r.UserId == userId && r.LessonId == lessonId)
                           .OrderByDescending(r => r.TakenAt)
                           .FirstOrDefault();
        }

        public UserModuleQuizResult AddUserModuleQuizResult(UserModuleQuizResult userModuleQuizResult)
        {
            _context.UserModuleQuizResults.Add(userModuleQuizResult);
            _context.SaveChanges();
            return userModuleQuizResult;
        }

        public UserModuleQuizResult UpdateUserModuleQuizResult(UserModuleQuizResult userModuleQuizResult)
        {
            _context.UserModuleQuizResults.Update(userModuleQuizResult);
            _context.SaveChanges();
            return userModuleQuizResult;
        }

        public bool DeleteUserModuleQuizResult(Guid resultId)
        {
            var result = _context.UserModuleQuizResults.FirstOrDefault(r => r.ResultId == resultId);
            if (result != null)
            {
                _context.UserModuleQuizResults.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
