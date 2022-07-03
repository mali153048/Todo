using ToDo.Domain.Entities;

namespace ToDo.Application.Responses
{
    public class TodoDetailsResponse : BaseResponse
    {
        public TodoDetailsResponse()
        {
            Todos = new List<Todo>();
        }
        public IEnumerable<Todo> Todos { get; set; }
        public bool TaskExists { get; set; } = true;
    }
}
