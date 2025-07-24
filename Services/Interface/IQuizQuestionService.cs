using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces.Quizzes
{
    public interface IQuizQuestionService
    {
        void Add(QuizQuestion quizQuestion);
        List<QuizQuestion> GetAll();
        QuizQuestion GetById(Guid id);
        bool Update(QuizQuestion quizQuestion);
        bool Delete(Guid id);
    }

}
