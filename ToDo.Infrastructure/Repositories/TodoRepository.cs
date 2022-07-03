using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Contracts.Repositories;
using ToDo.Domain.Entities;
using ToDo.Infrastructure.ConfigurationModels;

namespace ToDo.Infrastructure.Repositories
{
    public class TodoRepository : BaseRepository, ITodoRepository
    {
        public TodoRepository(IOptions<DBSettings> options) : base(options.Value)
        {
        }

        public async Task<int> DeleteTodoAsync(int id)
        {
            var sql = GetResourceFile("ToDo.Infrastructure.SQLQueries.Todo.DeleteTodo.sql", Assembly.GetExecutingAssembly());

            return await ExecuteAsync(sql,
                new
                {
                    ID = id,
                }).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Todo>> GetAllByUserIDAsync(int userID)
        {
            var sql = GetResourceFile("ToDo.Infrastructure.SQLQueries.Todo.GetAllByUserID.sql", Assembly.GetExecutingAssembly());

            var list = await QueryAsync<Todo>(sql,
                new
                {
                    UserID = userID

                }).ConfigureAwait(false);
            return list;
        }

        public async Task<Todo?> GetTodoAsync(int id)
        {
            var sql = GetResourceFile("ToDo.Infrastructure.SQLQueries.Todo.GetTodo.sql", Assembly.GetExecutingAssembly());

            return (await QueryAsync<Todo>(sql,
                new
                {
                    ID = id

                }).ConfigureAwait(false)).FirstOrDefault();
        }

        public async Task<int> NewTodoAync(Todo todo)
        {
            var sql = GetResourceFile("ToDo.Infrastructure.SQLQueries.Todo.NewTodo.sql", Assembly.GetExecutingAssembly());

            return await ExecuteAsync(sql,
                new
                {
                    Title = todo.Title,
                    UserID = todo.UserID,
                    ParentID = todo.ParentID,
                    CreatedAt = todo.CreatedAt,
                    ModifiedAt = todo.ModifiedAt
                }).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Todo>> TodoDetailsAsync(int id)
        {
            var sql = GetResourceFile("ToDo.Infrastructure.SQLQueries.Todo.TodoDetails.sql", Assembly.GetExecutingAssembly());

            return (await QueryAsync<Todo>(sql,
                new
                {
                    TodoID = id

                }).ConfigureAwait(false)).AsEnumerable();
        }

        public async Task<int> UpdateTodoAync(Todo todo)
        {
            var sql = GetResourceFile("ToDo.Infrastructure.SQLQueries.Todo.UpdateTodo.sql", Assembly.GetExecutingAssembly());

            return await ExecuteAsync(sql,
                new
                {
                    ID = todo.ID,
                    Title = todo.Title,
                    ModifiedAt = todo.ModifiedAt
                }).ConfigureAwait(false);
        }
    }
}
