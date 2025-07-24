using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class SurveyOption
{
    public Guid OptionId { get; set; }

    public Guid QuestionId { get; set; }

    public string OptionText { get; set; } = null!;

    public int? ScoreValue { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual SurveyQuestion Question { get; set; } = null!;

    public virtual ICollection<UserSurveyAnswer> UserSurveyAnswers { get; set; } = new List<UserSurveyAnswer>();
}
