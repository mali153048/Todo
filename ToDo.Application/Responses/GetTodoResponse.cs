using ToDo.Application.DTO;

namespace ToDo.Application.Responses
{
    public class GetTodoResponse : BaseResponse
    {
        public TodoDTO Todo { get; set; }
    }
}
