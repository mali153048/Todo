using ToDo.Application.DTO;

namespace ToDo.Application.Responses
{
    public class TodoListResponse : BaseResponse
    {
        public TodoListResponse()
        {
            Todos = Enumerable.Empty<TodoDTO>();
        }
        public IEnumerable<TodoDTO> Todos { get; set; }
    }
}
