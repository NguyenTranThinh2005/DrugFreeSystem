using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace Repositories.Interface.QuizRepo
{
    public interface IQuizRepository
    {
        List<Quiz> GetAll();
        Quiz? GetById(Guid id);
        Quiz Create(Quiz quiz);
        bool Update(Quiz quiz);
        bool Delete(Guid id);
        Quiz? GetQuizByLessonId(Guid lessonId);
        Quiz? GetQuizWithQuestionsAndOptionsByLessonId(Guid lessonId);
    }
}
