using BusinessObjects;
using DataAccessLayer;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class PracticeExerciseRepository : IPracticeExerciseRepository
    {
        private readonly DrugPreventSystemContext _context;

        public PracticeExerciseRepository(DrugPreventSystemContext context)
        {
            _context = context;
        }

        public PracticeExercise? Add(PracticeExercise entity)
        {
            _context.PracticeExercises.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<PracticeExercise> GetAll()
        {
            return _context.PracticeExercises.ToList();
        }

        public PracticeExercise? GetById(int id)
        {
            return _context.PracticeExercises.Find(id);
        }

        public bool Update(PracticeExercise entity)
        {
            var existing = _context.PracticeExercises.Find(entity.ExerciseId);
            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _context.PracticeExercises.Find(id);
            if (entity == null)
                return false;

            _context.PracticeExercises.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<PracticeExercise> GetByLessonId(int lessonId)
        {
            return _context.PracticeExercises
                .Where(pe => pe.LessonId == lessonId)
                .ToList();
        }
    }
}
