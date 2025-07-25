using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Lesson
{
    public int LessonId { get; set; }

    public int CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public int? DurationMinutes { get; set; }

    public int Sequence { get; set; }

    public bool HasQuiz { get; set; }

    public bool HasPractice { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<LessonResource> LessonResources { get; set; } = new List<LessonResource>();

    public virtual ICollection<PracticeExercise> PracticeExercises { get; set; } = new List<PracticeExercise>();

    public virtual Quiz? Quiz { get; set; }

    public virtual ICollection<UserLessonProgress> UserLessonProgresses { get; set; } = new List<UserLessonProgress>();

    public virtual ICollection<UserModuleQuizResult> UserModuleQuizResults { get; set; } = new List<UserModuleQuizResult>();
}
