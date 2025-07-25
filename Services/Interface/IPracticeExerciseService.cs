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
        PracticeExercise GetById(int id);
        bool Delete(int id);
        bool Update(PracticeExercise exercise);
        List<PracticeExercise> GetByLessonId(int lessonId);
    }
} 