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
        UserLessonProgress? GetById(int progressId);
        List<UserLessonProgress> GetByUserId(int userId);
        List<UserLessonProgress> GetByLessonId(int lessonId);
        void Add(UserLessonProgress progress);
        bool Update(UserLessonProgress progress);
        bool Delete(int progressId);
    }
}
