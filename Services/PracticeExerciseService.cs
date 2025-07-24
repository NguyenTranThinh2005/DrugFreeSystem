using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugPreventionSystem.BusinessLogic.Services
{
    public class PracticeExerciseService : IPracticeExerciseService
    {
        private readonly IPracticeExerciseRepository _repo;

        public PracticeExerciseService(IPracticeExerciseRepository repo)
        {
            _repo = repo;
        }

        public void Add(PracticeExercise exercise)
        {
            if (exercise == null)
                throw new ArgumentNullException(nameof(exercise));

            _repo.Add(exercise);
        }

        public List<PracticeExercise> GetAll()
        {
            return _repo.GetAll().ToList();
        }

        public PracticeExercise GetById(Guid id)
        {
            var exercise = _repo.GetById(id);
            if (exercise == null)
                throw new KeyNotFoundException($"PracticeExercise with ID {id} not found.");

            return exercise;
        }

        public bool Delete(Guid id)
        {
            var existing = _repo.GetById(id);
            if (existing == null)
                return false;

            return _repo.Delete(id);
        }

        public bool Update(PracticeExercise exercise)
        {
            var existing = _repo.GetById(exercise.ExerciseId);
            if (existing == null)
                return false;

            // Update fields
            existing.LessonId = exercise.LessonId;
            existing.Instruction = exercise.Instruction;
            existing.AttachmentUrl = exercise.AttachmentUrl;

            return _repo.Update(existing);
        }

        public List<PracticeExercise> GetByLessonId(Guid lessonId)
        {
            return _repo.GetByLessonId(lessonId).ToList();
        }
    }
} 