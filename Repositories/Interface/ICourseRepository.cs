using BusinessObjects;
using System;
using System.Collections.Generic;

namespace Repositories.Interface
{
    public interface ICourseRepository
    {
        Course? Create(Course course);
        void Update(Course course);
        void Delete(Guid id);
        List<Course> GetAll();
        Course? GetById(Guid id);
        List<Course> GetAllActiveCoursesWithAgeGroup(string? ageGroup = null);
        Course? GetCourseContentForEdit(Guid courseId);
    }
}
