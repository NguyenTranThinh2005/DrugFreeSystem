using BusinessObjects;
using DataAccessLayer;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DrugPreventSystemContext _context;

        public CourseRepository(DrugPreventSystemContext context)
        {
            _context = context;
        }

        public Course Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public List<Course> GetAll()
        {
            return _context.Courses
                .Where(c => c.IsActive)
                .ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses
                .Include(c => c.Lessons)
                .FirstOrDefault(c => c.CourseId == id);
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        public List<Course> GetAllActiveCoursesWithAgeGroup(string? ageGroup = null)
        {
            var query = _context.Courses.Where(c => c.IsActive);

            if (!string.IsNullOrEmpty(ageGroup))
            {
                query = query.Where(c => c.AgeGroup != null &&
                                         EF.Functions.Like(c.AgeGroup, $"%{ageGroup}%"));
            }

            return query.ToList();
        }

        public Course? GetCourseContentForEdit(int courseId)
        {
            return _context.Courses
                .Include(c => c.Lessons.OrderBy(l => l.Sequence))
                    .ThenInclude(l => l.LessonResources)
                .FirstOrDefault(c => c.CourseId == courseId);
        }

    }
}
