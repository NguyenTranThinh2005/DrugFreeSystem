using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public bool IsActive { get; set; }

    public bool EmailVerified { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<CourseCertificate> CourseCertificates { get; set; } = new List<CourseCertificate>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<UserCourseEnrollment> UserCourseEnrollments { get; set; } = new List<UserCourseEnrollment>();

    public virtual ICollection<UserLessonProgress> UserLessonProgresses { get; set; } = new List<UserLessonProgress>();

    public virtual ICollection<UserModuleQuizResult> UserModuleQuizResults { get; set; } = new List<UserModuleQuizResult>();

    public virtual ICollection<UserQuizAnswer> UserQuizAnswers { get; set; } = new List<UserQuizAnswer>();

    public virtual ICollection<UserSurveyResponse> UserSurveyResponses { get; set; } = new List<UserSurveyResponse>();
}
