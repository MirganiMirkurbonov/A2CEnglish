namespace BotService.Options;

public record BotOptions(string Token)
{
    public BotOptions() : this(string.Empty)
    {
    }
};