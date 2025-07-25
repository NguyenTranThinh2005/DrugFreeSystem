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
        UserQuizAnswer? GetById(int id);
        List<UserQuizAnswer> GetByUserId(int userId);
        List<UserQuizAnswer> GetByQuestionId(int questionId);
        void Add(UserQuizAnswer answer);
        bool Update(UserQuizAnswer answer);
        bool Delete(int id);
    }
}
