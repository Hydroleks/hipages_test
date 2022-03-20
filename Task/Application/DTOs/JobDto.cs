namespace Application.DTOs;
public class JobDto
{
    public Guid Id { get; set; }

    public string Status { get; set; }

    public string Suburb { get; set; }

    public string Category { get; set; }

    public string ContactName { get; set; }

    public string ContactPhone { get; set; }

    public string ContactEmail { get; set; }

    public int Price { get; set; }

    public string Description { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
}