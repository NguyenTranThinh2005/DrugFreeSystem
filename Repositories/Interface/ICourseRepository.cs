using BusinessObjects;
using System;
using System.Collections.Generic;

namespace Repositories.Interface
{
    public interface ICourseRepository
    {
        Course? Create(Course course);
        void Update(Course course);
        void Delete(int id);
        List<Course> GetAll();
        Course? GetById(int id);
        List<Course> GetAllActiveCoursesWithAgeGroup(string? ageGroup = null);
        Course? GetCourseContentForEdit(int courseId);
    }
}
