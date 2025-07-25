using System;
using System.Collections.Generic;
using BusinessObjects;

namespace Repositories.Interface.LessonRepo
{
    public interface ILessonRepository
    {
        Lesson? Add(Lesson lesson);
        List<Lesson> GetAll();
        Lesson? GetById(int id);
        bool Update(Lesson lesson);
        bool Delete(int id);
    }
}
