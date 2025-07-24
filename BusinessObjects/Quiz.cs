using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Quiz
{
    public Guid QuizId { get; set; }

    public Guid LessonId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public double? PassingScore { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
}
