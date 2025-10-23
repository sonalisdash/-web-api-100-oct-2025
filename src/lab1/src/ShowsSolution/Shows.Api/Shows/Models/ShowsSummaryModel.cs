namespace Shows.Api.Shows.Models;

public class ShowsSummaryModelCollection<T>
{
    public IList<T> Data { get; set; } = new List<T>();
}

public record ShowSummaryItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
