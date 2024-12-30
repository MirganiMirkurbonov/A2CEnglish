using Database.Models;

namespace Database.Tables;

public class Permission : BaseEntity
{
    public string Name { get; set; }
    public string Keyword { get; set; }
}