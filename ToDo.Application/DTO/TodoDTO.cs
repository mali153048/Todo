
namespace ToDo.Application.DTO
{
    public class TodoDTO
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int ParentID { get; set; }
    }
}
