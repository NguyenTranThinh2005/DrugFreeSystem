using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class PracticeExercise
{
    public Guid ExerciseId { get; set; }

    public Guid LessonId { get; set; }

    public string? Instruction { get; set; }

    public string? AttachmentUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;
}
