using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface.LessonRepo;

namespace DrugPreventionSystem.BusinessLogic.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public void Add(Lesson lesson)
        {
            if (lesson == null)
            {
                throw new ArgumentNullException(nameof(lesson));
            }

            _lessonRepository.Add(lesson);
        }

        public List<Lesson> GetAll()
        {
            return _lessonRepository.GetAll().ToList();
        }

        public Lesson GetById(Guid id)
        {
            var lesson = _lessonRepository.GetById(id);
            if (lesson == null)
            {
                throw new KeyNotFoundException($"Lesson with ID {id} not found.");
            }

            return lesson;
        }

        public bool Delete(Guid id)
        {
            var existing = _lessonRepository.GetById(id);
            if (existing == null)
            {
                return false;
            }

            return _lessonRepository.Delete(id);
        }

        public bool Update(Lesson lesson)
        {
            var existing = _lessonRepository.GetById(lesson.LessonId);
            if (existing == null)
            {
                return false;
            }

            // Update fields
            existing.Title = lesson.Title;
            existing.DurationMinutes = lesson.DurationMinutes;
            existing.Sequence = lesson.Sequence;
            existing.HasQuiz = lesson.HasQuiz;
            existing.HasPractice = lesson.HasPractice;
            existing.Content = lesson.Content;
            existing.UpdatedAt = DateTime.Now;

            return _lessonRepository.Update(existing);
        }
    }

} 