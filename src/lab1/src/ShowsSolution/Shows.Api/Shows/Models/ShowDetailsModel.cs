namespace Shows.Api.Shows.Models;

public class ShowDetailsModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string StreamingService { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
}
