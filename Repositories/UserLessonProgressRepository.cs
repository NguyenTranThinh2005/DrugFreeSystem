using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface.UserRepo;

namespace Repositories
{
    public class UserLessonProgressRepository : IUserLessonProgressRepository
    {
        private readonly DrugPreventSystemContext _context;

        public UserLessonProgressRepository(DrugPreventSystemContext context)
        {
            _context = context;
        }

        public List<UserLessonProgress> GetUserLessonProgresses()
        {
            return _context.UserLessonProgresses.ToList();
        }

        public UserLessonProgress? GetUserLessonProgressById(int progressId)
        {
            return _context.UserLessonProgresses.FirstOrDefault(ulp => ulp.ProgressId == progressId);
        }

        public List<UserLessonProgress> GetUserLessonProgressByUserId(int userId)
        {
            return _context.UserLessonProgresses
                .Where(ulp => ulp.UserId == userId)
                .ToList();
        }

        public List<UserLessonProgress> GetUserLessonProgressByLessonId(int lessonId)
        {
            return _context.UserLessonProgresses
                .Where(ulp => ulp.LessonId == lessonId)
                .ToList();
        }

        public UserLessonProgress AddUserLessonProgress(UserLessonProgress userLessonProgress)
        {
            _context.UserLessonProgresses.Add(userLessonProgress);
            _context.SaveChanges();
            return userLessonProgress;
        }

        public UserLessonProgress UpdateUserLessonProgress(UserLessonProgress userLessonProgress)
        {
            _context.UserLessonProgresses.Update(userLessonProgress);
            _context.SaveChanges();
            return userLessonProgress;
        }

        public bool DeleteUserLessonProgress(int progressId)
        {
            var progress = _context.UserLessonProgresses.FirstOrDefault(p => p.ProgressId == progressId);
            if (progress != null)
            {
                _context.UserLessonProgresses.Remove(progress);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<UserLessonProgress> GetUserLessonProgressByUserIdAndCourseId(int userId, int courseId)
        {
            return _context.UserLessonProgresses
                .Where(ulp => ulp.UserId == userId && ulp.Lesson != null && ulp.Lesson.CourseId == courseId)
                .Include(ulp => ulp.Lesson)
                .ToList();
        }

        public List<UserLessonProgress> GetAllUserLessonProgressesByUserId(int userId)
        {
            return _context.UserLessonProgresses
                .Where(ulp => ulp.UserId == userId)
                .Include(ulp => ulp.Lesson)
                .ToList();
        }

        public UserLessonProgress? GetUserLessonProgressByUserIdAndLessonId(int userId, int lessonId)
        {
            return _context.UserLessonProgresses
                .FirstOrDefault(ulp => ulp.UserId == userId && ulp.LessonId == lessonId);
        }

        public int CountCompletedLessonsForUserInCourse(int userId, int courseId)
        {
            return _context.UserLessonProgresses
                .Count(ulp => ulp.UserId == userId && ulp.Passed && ulp.Lesson.CourseId == courseId);
        }
    }
}
