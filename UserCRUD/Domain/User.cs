using System.ComponentModel.DataAnnotations.Schema;

namespace UserCRUD.Domain;

[Table("users")]
public class User : BaseModel
{
    [Column("name")] public string Name { get; set; }
    [Column("surname")] public string Surname { get; set; }
    [Column("phome_number")] public string PhoneNumber { get; set; }
    [Column("email")] public string Email { get; set; }
    [Column("password")] public string Password { get; set; }
}