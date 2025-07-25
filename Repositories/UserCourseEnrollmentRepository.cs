using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface.UserRepo;

namespace Repositories
{
    public class UserCourseEnrollmentRepository : IUserCourseEnrollmentRepository
    {
        private readonly DrugPreventSystemContext _context;

        public UserCourseEnrollmentRepository(DrugPreventSystemContext context)
        {
            _context = context;
        }

        public UserCourseEnrollment Add(UserCourseEnrollment entity)
        {
            _context.UserCourseEnrollments.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<UserCourseEnrollment> GetAll()
        {
            return _context.UserCourseEnrollments.ToList();
        }

        public UserCourseEnrollment? GetById(int id)
        {
            return _context.UserCourseEnrollments.Find(id);
        }

        public bool Update(UserCourseEnrollment entity)
        {
            _context.UserCourseEnrollments.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _context.UserCourseEnrollments.Find(id);
            if (entity != null)
            {
                _context.UserCourseEnrollments.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<UserCourseEnrollment> GetByUserId(int userId)
        {
            return _context.UserCourseEnrollments
                .Where(x => x.UserId == userId)
                .Include(x => x.Course)
                    .ThenInclude(c => c.Lessons)
                .ToList();
        }

        public List<UserCourseEnrollment> GetByCourseId(int courseId)
        {
            return _context.UserCourseEnrollments
                .Where(x => x.CourseId == courseId)
                .ToList();
        }

        public UserCourseEnrollment? GetByUserIdAndCourseId(int userId, int courseId)
        {
            return _context.UserCourseEnrollments
                .FirstOrDefault(x => x.UserId == userId && x.CourseId == courseId);
        }
    }
}
