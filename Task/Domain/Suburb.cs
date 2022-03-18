using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain;

public class Suburb
{
    [NotNull]
    public Guid Id { get; set; }

    [NotNull]
    [MaxLength(255)]
    public string Name { get; set; }

    [NotNull]
    [MaxLength(4)]
    public string PostCode { get; set; }
}