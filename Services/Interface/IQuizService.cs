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
        Quiz GetById(Guid id);
        bool Update(Quiz quiz);
        bool Delete(Guid id);
        Quiz GetQuizByLessonIdForEdit(Guid lessonId);
    }

}
