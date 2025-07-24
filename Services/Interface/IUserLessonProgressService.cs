using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface IUserLessonProgressService
    {
        List<UserLessonProgress> GetAll();
        UserLessonProgress? GetById(Guid progressId);
        List<UserLessonProgress> GetByUserId(Guid userId);
        List<UserLessonProgress> GetByLessonId(Guid lessonId);
        void Add(UserLessonProgress progress);
        bool Update(UserLessonProgress progress);
        bool Delete(Guid progressId);
    }
}
