using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class UserLessonProgress
{
    public int ProgressId { get; set; }

    public int UserId { get; set; }

    public int LessonId { get; set; }

    public DateTime? CompletedAt { get; set; }

    public double? QuizScore { get; set; }

    public bool Passed { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
