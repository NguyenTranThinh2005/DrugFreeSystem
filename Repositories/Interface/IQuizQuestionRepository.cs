using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace Repositories.Interface.QuizRepo
{
    public interface IQuizQuestionRepository
    {
        List<QuizQuestion> GetAll();
        QuizQuestion? GetById(Guid id);
        QuizQuestion Create(QuizQuestion quiz);
        bool Update(QuizQuestion quiz);
        bool Delete(Guid id);
    }
}
