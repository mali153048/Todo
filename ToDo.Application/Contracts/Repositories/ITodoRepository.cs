using ToDo.Domain.Entities;

namespace ToDo.Application.Contracts.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllByUserIDAsync(int userID);

        Task<int> NewTodoAync(Todo todo);
        Task<Todo?> GetTodoAsync(int id);
        Task<int> UpdateTodoAync(Todo todo);
        Task<int> DeleteTodoAsync(int value);
        Task<IEnumerable<Todo>> TodoDetailsAsync(int id);
    }
}
