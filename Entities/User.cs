using SQLite;

namespace MauiAppXml.Entities;

[Table("users")]
public class User
{
    [PrimaryKey, AutoIncrement, Column("_id")]
    public int Id { get; set; }

    [MaxLength(50)]
    public string Email { get; set; }

    [MaxLength(50)]
    public string Password { get; set; }
}
