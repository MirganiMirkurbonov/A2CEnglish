using Database.Enums;
using Database.Models;

namespace Database.Tables;

public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public EnglishLevel EnglishLevel { get; set; } = EnglishLevel.A1;
    public string? TelegramChatId { get; set; }
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }
    public List<UserSession> UserSessions { get; set; }
}