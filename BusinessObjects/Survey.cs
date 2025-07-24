using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Survey
{
    public Guid SurveyId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? TargetAudience { get; set; }

    public string? EstimatedDuration { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; } = new List<SurveyQuestion>();

    public virtual ICollection<UserSurveyResponse> UserSurveyResponses { get; set; } = new List<UserSurveyResponse>();
}
