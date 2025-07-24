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
        UserCourseEnrollment? GetById(Guid id);
        bool Delete(Guid id);
        bool Update(UserCourseEnrollment enrollment);
        List<UserCourseEnrollment> GetByUserId(Guid userId);
        List<UserCourseEnrollment> GetByCourseId(Guid courseId);
    }
} 