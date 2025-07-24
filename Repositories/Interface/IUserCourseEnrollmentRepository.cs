using System;
using System.Collections.Generic;
using BusinessObjects;

namespace Repositories.Interface.UserRepo
{
    public interface IUserCourseEnrollmentRepository
    {
        UserCourseEnrollment Add(UserCourseEnrollment entity);
        List<UserCourseEnrollment> GetAll();
        UserCourseEnrollment? GetById(Guid id);
        bool Update(UserCourseEnrollment entity);
        bool Delete(Guid id);
        List<UserCourseEnrollment> GetByUserId(Guid userId);
        List<UserCourseEnrollment> GetByCourseId(Guid courseId);
        UserCourseEnrollment? GetByUserIdAndCourseId(Guid userId, Guid courseId);
    }
}
