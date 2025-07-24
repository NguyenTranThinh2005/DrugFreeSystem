using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class UserQuizAnswer
{
    public Guid UserQuizAnswerId { get; set; }

    public Guid UserId { get; set; }

    public Guid QuestionId { get; set; }

    public Guid? SelectedOptionId { get; set; }

    public string? AnswerText { get; set; }

    public DateTime AnsweredAt { get; set; }

    public virtual QuizQuestion Question { get; set; } = null!;

    public virtual QuizOption? SelectedOption { get; set; }

    public virtual User User { get; set; } = null!;
}
