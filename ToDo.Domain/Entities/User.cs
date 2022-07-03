
namespace ToDo.Domain.Entities
{
    public class User : AuditableEntity
    {
        public int ID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
    }
}
