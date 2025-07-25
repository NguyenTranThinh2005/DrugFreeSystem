using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class CourseCertificate
{
    public int CertificateId { get; set; }

    public int UserId { get; set; }

    public int CourseId { get; set; }

    public DateTime IssuedAt { get; set; }

    public string? CertificateUrl { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
