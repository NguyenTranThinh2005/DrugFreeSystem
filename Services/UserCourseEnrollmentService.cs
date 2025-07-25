using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using DrugPreventionSystem.DataAccess.Repository;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Repositories.Interface.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugPreventionSystem.BusinessLogic.Services
{
    public class UserCourseEnrollmentService : IUserCourseEnrollmentService
    {
        private readonly IUserCourseEnrollmentRepository _repo;

        public UserCourseEnrollmentService(IUserCourseEnrollmentRepository repo)
        {
            _repo = repo;
        }

        public List<UserCourseEnrollment> GetAll() => _repo.GetAll();

        public UserCourseEnrollment? GetById(int id) => _repo.GetById(id);

        public void Add(UserCourseEnrollment enrollment) => _repo.Add(enrollment);

        public bool Update(UserCourseEnrollment enrollment) => _repo.Update(enrollment);

        public bool Delete(int id) => _repo.Delete(id);

        public List<UserCourseEnrollment> GetByUserId(int userId) => _repo.GetByUserId(userId);

        public List<UserCourseEnrollment> GetByCourseId(int courseId) => _repo.GetByCourseId(courseId);

    }
} 