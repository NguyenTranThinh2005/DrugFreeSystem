using BusinessObjects;
using System;
using System.Collections.Generic;

namespace Repositories.Interface
{
    public interface ICourseCertificateRepository
    {
        CourseCertificate? Add(CourseCertificate entity);
        List<CourseCertificate> GetAll();
        CourseCertificate? GetById(int id);
        bool Update(CourseCertificate entity);
        bool Delete(int id);
        List<CourseCertificate> GetByUserId(int userId);
        List<CourseCertificate> GetByCourseId(int courseId);
        CourseCertificate? GetByUserIdAndCourseId(int userId, int courseId);
    }
}
