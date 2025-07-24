using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class LessonResource
{
    public Guid ResourceId { get; set; }

    public Guid LessonId { get; set; }

    public string ResourceType { get; set; } = null!;

    public string ResourceUrl { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;
}
