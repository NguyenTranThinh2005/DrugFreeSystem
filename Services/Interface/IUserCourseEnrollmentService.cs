using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObjects;

namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface IUserCourseEnrollmentService
    {
        void Add(UserCourseEnrollment enrollment);
        List<UserCourseEnrollment> GetAll();
        UserCourseEnrollment? GetById(int id);
        bool Delete(int id);
        bool Update(UserCourseEnrollment enrollment);
        List<UserCourseEnrollment> GetByUserId(int userId);
        List<UserCourseEnrollment> GetByCourseId(int courseId);
    }
} 