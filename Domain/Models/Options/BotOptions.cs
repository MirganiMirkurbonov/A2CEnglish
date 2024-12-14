namespace Domain.Models.Options;

public record BotOptions(string Token, string DictionaryBaseUrl)
{
    public BotOptions() : this(string.Empty, string.Empty)
    {
    }
};