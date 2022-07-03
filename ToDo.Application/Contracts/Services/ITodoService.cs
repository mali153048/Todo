using System;
using ToDo.Application.DTO;
using ToDo.Application.Responses;

namespace ToDo.Application.Contracts.Services
{
    public interface ITodoService
    {
        Task<TodoListResponse> GetAllByUserIDAsync(int userID);

        Task<BaseResponse> NewTodoAsync(NewTodoDTO model);

        Task<GetTodoResponse> GetTodoAsync(int id);
        Task<BaseResponse> UpdateTodoAsync(NewTodoDTO model);
        Task<BaseResponse> DeleteTodoAsync(int id);
        Task<TodoDetailsResponse> TodoDetailsAsync(int id);
    }
}
