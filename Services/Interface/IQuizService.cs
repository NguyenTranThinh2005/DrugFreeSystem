using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces.Quizzes
{
    public interface IQuizService
    {
        void Add(Quiz quiz);
        List<Quiz> GetAll();
        Quiz GetById(int id);
        bool Update(Quiz quiz);
        bool Delete(int id);
        Quiz GetQuizByLessonIdForEdit(int lessonId);
    }

}
