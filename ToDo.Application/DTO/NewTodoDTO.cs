
namespace ToDo.Application.DTO
{
    public class NewTodoDTO
    {
        public int? ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int? UserID { get; set; }
        public int? ParentID { get; set; } = null;
    }
}
