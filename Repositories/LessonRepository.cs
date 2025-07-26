using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface.LessonRepo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly DrugPreventSystemContext _context;

        public LessonRepository(DrugPreventSystemContext context)
        {
            _context = context;
        }

        public Lesson? Add(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            _context.SaveChanges();
            return lesson;
        }

        public List<Lesson> GetAll()
        {
            return _context.Lessons
                .Include(l => l.Course)
                .Include(l => l.LessonResources)
                .ToList();
        }
        public Lesson? GetById(int id)
        {
            return _context.Lessons
                .Include(l => l.LessonResources)
                .Include(l => l.Course)
                    .ThenInclude(c => c.Lessons)
                .Include(l => l.UserLessonProgresses)
                .FirstOrDefault(l => l.LessonId == id);
        }

        public bool Update(Lesson lesson)
        {
            var existingLesson = _context.Lessons.Find(lesson.LessonId);
            if (existingLesson == null)
                return false;

            _context.Entry(existingLesson).CurrentValues.SetValues(lesson);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var lesson = _context.Lessons.Find(id);
            if (lesson == null)
                return false;

            _context.Lessons.Remove(lesson);
            _context.SaveChanges();
            return true;
        }
    }
}
