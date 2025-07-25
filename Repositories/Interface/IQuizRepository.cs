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
        Quiz? GetById(int id);
        Quiz Create(Quiz quiz);
        bool Update(Quiz quiz);
        bool Delete(int id);
        Quiz? GetQuizByLessonId(int lessonId);
        Quiz? GetQuizWithQuestionsAndOptionsByLessonId(int lessonId);
    }
}
