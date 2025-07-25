using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class UserQuizAnswer
{
    public int UserQuizAnswerId { get; set; }

    public int UserId { get; set; }

    public int QuestionId { get; set; }

    public int? SelectedOptionId { get; set; }

    public string? AnswerText { get; set; }

    public DateTime AnsweredAt { get; set; }

    public virtual QuizQuestion Question { get; set; } = null!;

    public virtual QuizOption? SelectedOption { get; set; }

    public virtual User User { get; set; } = null!;
}
