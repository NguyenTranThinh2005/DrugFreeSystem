using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces.Quizzes
{
    public interface IQuizOptionService
    {
        void Add(QuizOption quizOption);
        List<QuizOption> GetAll();
        QuizOption GetById(int id);
        bool Update(QuizOption quizOption);
        bool Delete(int id);
    }

}
