using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface.LessonRepo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class LessonResourceRepository : ILessonResourceRepository
    {
        private readonly DrugFreeSystemDbContext _context;

        public LessonResourceRepository(DrugFreeSystemDbContext context)
        {
            _context = context;
        }

        public LessonResource? Add(LessonResource entity)
        {
            _context.LessonResources.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<LessonResource> GetAll()
        {
            return _context.LessonResources
                .Include(lr => lr.Lesson)
                .ToList();
        }

        public LessonResource? GetById(Guid id)
        {
            return _context.LessonResources
                .Include(lr => lr.Lesson)
                .FirstOrDefault(lr => lr.ResourceId == id);
        }

        public bool Update(LessonResource entity)
        {
            var existing = _context.LessonResources.Find(entity.ResourceId);
            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(Guid id)
        {
            var entity = _context.LessonResources.Find(id);
            if (entity == null)
                return false;

            _context.LessonResources.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<LessonResource> GetByLessonId(Guid lessonId)
        {
            return _context.LessonResources
                .Where(lr => lr.LessonId == lessonId)
                .Include(lr => lr.Lesson)
                .ToList();
        }
    }
}
