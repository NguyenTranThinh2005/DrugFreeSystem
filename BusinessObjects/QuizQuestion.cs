using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class QuizQuestion
{
    public int QuestionId { get; set; }

    public int QuizId { get; set; }

    public string QuestionText { get; set; } = null!;

    public string? QuestionType { get; set; }

    public int Sequence { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Quiz Quiz { get; set; } = null!;

    public virtual ICollection<QuizOption> QuizOptions { get; set; } = new List<QuizOption>();

    public virtual ICollection<UserQuizAnswer> UserQuizAnswers { get; set; } = new List<UserQuizAnswer>();
}
