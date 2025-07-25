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
        PracticeExercise? GetById(int id);
        bool Update(PracticeExercise entity);
        bool Delete(int id);
        List<PracticeExercise> GetByLessonId(int lessonId);
    }
} 