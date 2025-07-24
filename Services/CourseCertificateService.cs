
using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using DrugPreventionSystem.DataAccess.Repository;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugPreventionSystem.BusinessLogic.Services
{
    public class CourseCertificateService : ICourseCertificateService
    {
        private readonly ICourseCertificateRepository _repo;

        public CourseCertificateService(ICourseCertificateRepository repo)
        {
            _repo = repo;
        }

        public List<CourseCertificate> GetAll() => _repo.GetAll();

        public CourseCertificate? GetById(Guid id) => _repo.GetById(id);

        public void Add(CourseCertificate certificate) => _repo.Add(certificate);

        public bool Update(CourseCertificate certificate) => _repo.Update(certificate);

        public bool Delete(Guid id) => _repo.Delete(id);

        public List<CourseCertificate> GetByUserId(Guid userId) => _repo.GetByUserId(userId);

        public List<CourseCertificate> GetByCourseId(Guid courseId) => _repo.GetByCourseId(courseId);
    }
} 