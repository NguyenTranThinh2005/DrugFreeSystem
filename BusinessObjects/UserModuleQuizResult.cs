using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class UserModuleQuizResult
{
    public Guid ResultId { get; set; }

    public Guid UserId { get; set; }

    public Guid LessonId { get; set; }

    public double TotalScore { get; set; }

    public int CorrectCount { get; set; }

    public int TotalQuestions { get; set; }

    public string Status { get; set; } = null!;

    public DateTime TakenAt { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
