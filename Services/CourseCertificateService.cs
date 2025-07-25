
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

        public CourseCertificate? GetById(int id) => _repo.GetById(id);

        public void Add(CourseCertificate certificate) => _repo.Add(certificate);

        public bool Update(CourseCertificate certificate) => _repo.Update(certificate);

        public bool Delete(int id) => _repo.Delete(id);

        public List<CourseCertificate> GetByUserId(int userId) => _repo.GetByUserId(userId);

        public List<CourseCertificate> GetByCourseId(int courseId) => _repo.GetByCourseId(courseId);
    }
} 