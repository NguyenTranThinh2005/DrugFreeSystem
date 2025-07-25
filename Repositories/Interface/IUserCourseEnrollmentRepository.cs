using System;
using System.Collections.Generic;
using BusinessObjects;

namespace Repositories.Interface.UserRepo
{
    public interface IUserCourseEnrollmentRepository
    {
        UserCourseEnrollment Add(UserCourseEnrollment entity);
        List<UserCourseEnrollment> GetAll();
        UserCourseEnrollment? GetById(int id);
        bool Update(UserCourseEnrollment entity);
        bool Delete(int id);
        List<UserCourseEnrollment> GetByUserId(int userId);
        List<UserCourseEnrollment> GetByCourseId(int courseId);
        UserCourseEnrollment? GetByUserIdAndCourseId(int userId, int courseId);
    }
}
