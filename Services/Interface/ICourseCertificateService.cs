using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObjects;

namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface ICourseCertificateService
    {
        List<CourseCertificate> GetAll();
        CourseCertificate GetById(Guid id);
        void Add(CourseCertificate certificate);
        bool Update(CourseCertificate certificate);
        bool Delete(Guid id);
        List<CourseCertificate> GetByUserId(Guid userId);
        List<CourseCertificate> GetByCourseId(Guid courseId);
    }
}