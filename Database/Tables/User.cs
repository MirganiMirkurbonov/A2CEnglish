using Database.Enums;
using Database.Models;

namespace Database.Tables;

public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public EnglishLevel EnglishLevel { get; set; } = EnglishLevel.A1;
    public string? TelegramChatId { get; set; }
}