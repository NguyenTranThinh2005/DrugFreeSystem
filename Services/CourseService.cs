using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using DrugPreventionSystem.DataAccess.Repository;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Repositories.Interface;

namespace DrugPreventionSystem.BusinessLogic.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<Course> GetAll()
        {
            return _courseRepository.GetAll();
        }

        public Course? GetById(int id)
        {
            return _courseRepository.GetById(id);
        }


        public void Add(Course course)
        {
            _courseRepository.Create(course);
        }

        public bool Update(Course course)
        {
            var existingCourse = _courseRepository.GetById(course.CourseId);
            if (existingCourse == null) return false;

            existingCourse.Title = course.Title;
            existingCourse.Description = course.Description;
            existingCourse.AgeGroup = course.AgeGroup;
            existingCourse.IsActive = course.IsActive;
            existingCourse.TotalDuration = course.TotalDuration;
            existingCourse.LessonCount = course.LessonCount;
            existingCourse.StudentCount = course.StudentCount;
            existingCourse.Requirements = course.Requirements;
            existingCourse.ThumbnailUrl = course.ThumbnailUrl;
            existingCourse.CertificateAvailable = course.CertificateAvailable;
            existingCourse.UpdatedAt = DateTime.Now;

            _courseRepository.Update(existingCourse);
            return true;
        }

        public bool Delete(int id)
        {
            _courseRepository.Delete(id);
            return true;
        }
        public List<Course> GetCoursesByAgeGroup(string ageGroup)
        {
            throw new NotImplementedException();
        }
    }
}
    

