
namespace ToDo.Domain.Entities
{
    public class Todo : AuditableEntity
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int? ParentID { get; set; }
        public int UserID { get; set; }
    }
}
