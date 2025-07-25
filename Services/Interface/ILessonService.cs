
using System.Collections.Generic;
using System.Threading.Tasks;

using BusinessObjects;

namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface ILessonService
    {
        void Add(Lesson lesson);
        List<Lesson> GetAll();
        Lesson GetById(int id);
        bool Delete(int id);
        bool Update(Lesson lesson);

    }
}