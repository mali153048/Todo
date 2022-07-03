
namespace ToDo.Domain
{
    public class AuditableEntity
    {
        public AuditableEntity()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
