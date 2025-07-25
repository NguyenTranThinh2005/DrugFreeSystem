using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObjects;

namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface ICourseCertificateService
    {
        List<CourseCertificate> GetAll();
        CourseCertificate GetById(int id);
        void Add(CourseCertificate certificate);
        bool Update(CourseCertificate certificate);
        bool Delete(int id);
        List<CourseCertificate> GetByUserId(int userId);
        List<CourseCertificate> GetByCourseId(int courseId);
    }
}