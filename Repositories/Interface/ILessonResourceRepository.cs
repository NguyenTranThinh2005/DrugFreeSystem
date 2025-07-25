using System;
using System.Collections.Generic;
using BusinessObjects;

namespace Repositories.Interface.LessonRepo
{
    public interface ILessonResourceRepository
    {
        LessonResource? Add(LessonResource entity);
        List<LessonResource> GetAll();
        LessonResource? GetById(int id);
        bool Update(LessonResource entity);
        bool Delete(int id);
        List<LessonResource> GetByLessonId(int lessonId);
    }
}
