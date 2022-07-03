using AutoMapper;
using ToDo.Application.Contracts.Repositories;
using ToDo.Application.Contracts.Services;
using ToDo.Application.DTO;
using ToDo.Application.Responses;
using ToDo.Domain.Entities;

namespace ToDo.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly IMapper _mapper;
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;
        }

        public async Task<GetTodoResponse> GetTodoAsync(int id)
        {
            var response = new GetTodoResponse();

            try
            {
                var todo = await _todoRepository.GetTodoAsync(id).ConfigureAwait(false);
                if (todo != null)
                    response.Todo = _mapper.Map<TodoDTO>(todo);
                else
                    response.Success = false;
            }
            catch
            {
                response.Success = false;
            }

            return response;
        }

        public async Task<TodoListResponse> GetAllByUserIDAsync(int userID)
        {
            var response = new TodoListResponse();

            try
            {
                var todoList = await _todoRepository.GetAllByUserIDAsync(userID).ConfigureAwait(false);

                response.Todos = _mapper.Map<IEnumerable<TodoDTO>>(todoList);
            }
            catch
            {
                response.Success = false;
            }

            return response;
        }

        public async Task<BaseResponse> NewTodoAsync(NewTodoDTO model)
        {
            var response = new BaseResponse();
            try
            {
                var todo = _mapper.Map<Todo>(model);
                var result = await _todoRepository.NewTodoAync(todo).ConfigureAwait(false);
                if (result <= 0)
                    response.Success = false;
            }
            catch
            {
                response.Success = false;
            }

            return response;
        }

        public async Task<BaseResponse> UpdateTodoAsync(NewTodoDTO model)
        {
            var response = new BaseResponse();
            try
            {
                var todo = _mapper.Map<Todo>(model);

                var result = await _todoRepository.UpdateTodoAync(todo).ConfigureAwait(false);

                if (result <= 0)
                    response.Success = false;
            }
            catch
            {
                response.Success = false;
            }

            return response;
        }

        public async Task<BaseResponse> DeleteTodoAsync(int id)
        {
            var response = new BaseResponse();

            try
            {
                var result = await _todoRepository.DeleteTodoAsync(id).ConfigureAwait(false);

                if (result <= 0)
                    response.Success = false;
            }
            catch
            {
                response.Success = false;
            }

            return response;
        }

        public async Task<TodoDetailsResponse> TodoDetailsAsync(int id)
        {
            var response = new TodoDetailsResponse();
            try
            {
                var result = await _todoRepository.TodoDetailsAsync(id).ConfigureAwait(false);
                if (result != null)
                {
                    response.Todos = result;

                    if (!result.Any(x => x.ParentID != null) && result.Count() != 2)
                    {
                        response.TaskExists = false;
                    }
                }
                else
                {
                    response.Success = false;
                }

            }
            catch
            {
                response.Success = false;
            }

            return response;
        }
    }
}
