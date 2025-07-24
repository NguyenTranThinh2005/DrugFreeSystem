using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class UserSurveyResponse
{
    public Guid ResponseId { get; set; }

    public Guid UserId { get; set; }

    public Guid SurveyId { get; set; }

    public DateTime TakenAt { get; set; }

    public string? RiskLevel { get; set; }

    public string? RecommendedAction { get; set; }

    public virtual Survey Survey { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserSurveyAnswer> UserSurveyAnswers { get; set; } = new List<UserSurveyAnswer>();
}
