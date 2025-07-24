using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class UserSurveyAnswer
{
    public Guid AnswerId { get; set; }

    public Guid ResponseId { get; set; }

    public Guid QuestionId { get; set; }

    public Guid? OptionId { get; set; }

    public string? AnswerText { get; set; }

    public DateTime AnsweredAt { get; set; }

    public virtual SurveyOption? Option { get; set; }

    public virtual SurveyQuestion Question { get; set; } = null!;

    public virtual UserSurveyResponse Response { get; set; } = null!;
}
