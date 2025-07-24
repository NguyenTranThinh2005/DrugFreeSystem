using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface IUserQuizAnswerService
    {
        List<UserQuizAnswer> GetAll();
        UserQuizAnswer? GetById(Guid id);
        List<UserQuizAnswer> GetByUserId(Guid userId);
        List<UserQuizAnswer> GetByQuestionId(Guid questionId);
        void Add(UserQuizAnswer answer);
        bool Update(UserQuizAnswer answer);
        bool Delete(Guid id);
    }
}
