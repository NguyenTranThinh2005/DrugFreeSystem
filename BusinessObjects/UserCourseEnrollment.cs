using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class UserCourseEnrollment
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid CourseId { get; set; }

    public DateTime EnrolledAt { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CompletedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
