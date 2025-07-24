using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObjects;

namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface IPracticeExerciseService
    {
        void Add(PracticeExercise exercise);
        List<PracticeExercise> GetAll();
        PracticeExercise GetById(Guid id);
        bool Delete(Guid id);
        bool Update(PracticeExercise exercise);
        List<PracticeExercise> GetByLessonId(Guid lessonId);
    }
} 