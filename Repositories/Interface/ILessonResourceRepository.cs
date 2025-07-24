using System;
using System.Collections.Generic;
using BusinessObjects;

namespace Repositories.Interface.LessonRepo
{
    public interface ILessonResourceRepository
    {
        LessonResource? Add(LessonResource entity);
        List<LessonResource> GetAll();
        LessonResource? GetById(Guid id);
        bool Update(LessonResource entity);
        bool Delete(Guid id);
        List<LessonResource> GetByLessonId(Guid lessonId);
    }
}
