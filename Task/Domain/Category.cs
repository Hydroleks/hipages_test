using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain;

public class Category
{
    [NotNull]
    public Guid Id { get; set; }
    
    [NotNull]
    [MaxLength(255)]
    public string Name { get; set; }

    [NotNull]
    public Guid ParentCategoryId { get; set; }
}