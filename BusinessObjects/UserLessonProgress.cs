using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class UserLessonProgress
{
    public Guid ProgressId { get; set; }

    public Guid UserId { get; set; }

    public Guid LessonId { get; set; }

    public DateTime? CompletedAt { get; set; }

    public double? QuizScore { get; set; }

    public bool Passed { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
