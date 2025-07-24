using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObjects;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface IPracticeExerciseRepository
    {
        PracticeExercise? Add(PracticeExercise entity);
        List<PracticeExercise> GetAll();
        PracticeExercise? GetById(Guid id);
        bool Update(PracticeExercise entity);
        bool Delete(Guid id);
        List<PracticeExercise> GetByLessonId(Guid lessonId);
    }
} 