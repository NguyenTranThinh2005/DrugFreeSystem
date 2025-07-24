using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface ICourseService
    {
        void Add(Course course);
        List<Course> GetAll();
        Course GetById(Guid id);
        bool Update(Course course);
        bool Delete(Guid id);
        List<Course> GetCoursesByAgeGroup(string ageGroup);
    }
}
