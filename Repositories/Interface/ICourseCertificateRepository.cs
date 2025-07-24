using BusinessObjects;
using System;
using System.Collections.Generic;

namespace Repositories.Interface
{
    public interface ICourseCertificateRepository
    {
        CourseCertificate? Add(CourseCertificate entity);
        List<CourseCertificate> GetAll();
        CourseCertificate? GetById(Guid id);
        bool Update(CourseCertificate entity);
        bool Delete(Guid id);
        List<CourseCertificate> GetByUserId(Guid userId);
        List<CourseCertificate> GetByCourseId(Guid courseId);
        CourseCertificate? GetByUserIdAndCourseId(Guid userId, Guid courseId);
    }
}
