using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace Repositories.Interface.QuizRepo
{
    public interface IQuizOptionRepository
    {
        List<QuizOption> GetAll();
        QuizOption? GetById(Guid id);
        QuizOption Create(QuizOption option);
        bool Update(QuizOption option);
        bool Delete(Guid id);
    }
}
