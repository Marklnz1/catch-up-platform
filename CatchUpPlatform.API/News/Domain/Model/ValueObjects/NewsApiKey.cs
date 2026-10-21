namespace CatchUpPlatform.API.News.Domain.Model.ValueObjects;

public sealed record NewsApiKey
{
    private const int Maxlength = 255;
    public string Value { get; }

    public NewsApiKey(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("News API key cannot be null or empty.", nameof(value));
        if (value.Length > Maxlength)
            throw new ArgumentException($"News API key cannot be longer than {Maxlength} characters.", nameof(value));
        Value = value;
    }

    public override string ToString() => Value;

    public static string MaskedForLogging(string? value) =>
        string.IsNullOrEmpty(value)
            ? string.Empty
            : value.Length <= 4
                ? new string('*', value.Length)
                : new string('*', value.Length - 4) + value[^4..];

    public string MaskedForLogging() => MaskedForLogging(Value);
}