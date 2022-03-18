using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain;
public class Job
{
    [NotNull]
    public Guid Id { get; set; }

    [NotNull]
    [MaxLength(50)]
    public string Status { get; set; }

    [NotNull]
    public Guid SuburbId { get; set; }

    [NotNull]
    public Guid CategoryId { get; set; }

    [NotNull]
    [MaxLength(255)]
    public string ContactName { get; set; }

    [NotNull]
    [MaxLength(255)]
    public string ContactPhone { get; set; }

    [NotNull]
    [MaxLength(255)]
    public string ContactEmail { get; set; }

    [NotNull]
    public int Price { get; set; }

    [NotNull]
    public string Description { get; set; }

    [NotNull]
    public DateTime Created { get; set; }

    [NotNull]
    public DateTime Updated { get; set; }
}
