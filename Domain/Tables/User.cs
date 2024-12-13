using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Enums;

namespace Domain.Tables;

[Table("users")]
public class User : BaseEntity
{
    [Column("name")]
    public string Name { get; set; } = null!;
    
    [Column("phone")]
    public string? Phone { get; set; }
    
    [Column("email")]
    public string? Email { get; set; }

    [Column("english_level")]
    public EnglishLevel EnglishLevel { get; set; } = EnglishLevel.A1;
    
    [Column("telegram_chat_id")]
    public string? TelegramChatId { get; set; }
}