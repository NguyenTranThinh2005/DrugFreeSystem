using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class QuizOption
{
    public Guid OptionId { get; set; }

    public Guid QuestionId { get; set; }

    public string OptionText { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual QuizQuestion Question { get; set; } = null!;

    public virtual ICollection<UserQuizAnswer> UserQuizAnswers { get; set; } = new List<UserQuizAnswer>();
}
