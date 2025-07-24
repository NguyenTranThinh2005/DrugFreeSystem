using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObjects;

namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface ILessonResourceService
    {
        void Add(LessonResource lessonResource);
        List<LessonResource> GetAll();
        LessonResource GetById(Guid id);
        bool Delete(Guid id);
        bool Update(LessonResource lessonResource);
        List<LessonResource> GetByLessonId(Guid lessonId);
    }
} 