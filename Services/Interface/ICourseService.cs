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
        Course GetById(int id);
        bool Update(Course course);
        bool Delete(int id);
        List<Course> GetCoursesByAgeGroup(string ageGroup);
    }
}
