namespace Domain.Models;
public record Post : Entity
{
    public string? Content { get; set; }
}
