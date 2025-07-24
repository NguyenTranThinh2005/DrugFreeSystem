using BusinessObjects;
using DataAccessLayer;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class CourseCertificateRepository : ICourseCertificateRepository
    {
        private readonly DrugFreeSystemDbContext _context;

        public CourseCertificateRepository(DrugFreeSystemDbContext context)
        {
            _context = context;
        }

        public CourseCertificate? Add(CourseCertificate entity)
        {
            _context.CourseCertificates.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<CourseCertificate> GetAll()
        {
            return _context.CourseCertificates.ToList();
        }

        public CourseCertificate? GetById(Guid id)
        {
            return _context.CourseCertificates.Find(id);
        }

        public bool Update(CourseCertificate entity)
        {
            var existing = _context.CourseCertificates.Find(entity.CertificateId);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(Guid id)
        {
            var entity = _context.CourseCertificates.Find(id);
            if (entity == null) return false;

            _context.CourseCertificates.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<CourseCertificate> GetByUserId(Guid userId)
        {
            return _context.CourseCertificates.Where(x => x.UserId == userId).ToList();
        }

        public List<CourseCertificate> GetByCourseId(Guid courseId)
        {
            return _context.CourseCertificates.Where(x => x.CourseId == courseId).ToList();
        }

        public CourseCertificate? GetByUserIdAndCourseId(Guid userId, Guid courseId)
        {
            return _context.CourseCertificates
                .FirstOrDefault(cc => cc.UserId == userId && cc.CourseId == courseId);
        }
    }
}
