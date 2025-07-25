using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface IUserModuleQuizResultService
    {
        List<UserModuleQuizResult> GetAll();
        UserModuleQuizResult? GetById(int resultId);
        List<UserModuleQuizResult> GetByUserId(int userId);
        List<UserModuleQuizResult> GetByLessonId(int lessonId);
        void Add(UserModuleQuizResult result);
        bool Update(UserModuleQuizResult result);
        bool Delete(int resultId);
    }
}
