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
        LessonResource GetById(int id);
        bool Delete(int id);
        bool Update(LessonResource lessonResource);
        List<LessonResource> GetByLessonId(int lessonId);
    }
} 