using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Course
{
    public Guid CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? AgeGroup { get; set; }

    public bool IsActive { get; set; }

    public int? TotalDuration { get; set; }

    public int? LessonCount { get; set; }

    public int? StudentCount { get; set; }

    public string? Requirements { get; set; }

    public bool CertificateAvailable { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? ThumbnailUrl { get; set; }

    public virtual ICollection<CourseCertificate> CourseCertificates { get; set; } = new List<CourseCertificate>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<UserCourseEnrollment> UserCourseEnrollments { get; set; } = new List<UserCourseEnrollment>();
}
