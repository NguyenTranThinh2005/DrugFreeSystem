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
        UserModuleQuizResult? GetById(Guid resultId);
        List<UserModuleQuizResult> GetByUserId(Guid userId);
        List<UserModuleQuizResult> GetByLessonId(Guid lessonId);
        void Add(UserModuleQuizResult result);
        bool Update(UserModuleQuizResult result);
        bool Delete(Guid resultId);
    }
}
