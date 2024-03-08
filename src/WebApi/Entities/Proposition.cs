



namespace WebApi.Entities
{
    public record Proposition
    {
        public Guid Id { get; init; }
        public string Text { get; init; } = String.Empty;
    }
}