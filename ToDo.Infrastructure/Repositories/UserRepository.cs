using Microsoft.Extensions.Options;
using System.Reflection;
using ToDo.Application.Contracts.Repositories;
using ToDo.Domain.Entities;
using ToDo.Infrastructure.ConfigurationModels;

namespace ToDo.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IOptions<DBSettings> options) : base(options.Value)
        {
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var sql = GetResourceFile("ToDo.Infrastructure.SQLQueries.User.GetUserByUsername.sql", Assembly.GetExecutingAssembly());
            return (await QueryAsync<User>(sql,
                new
                {
                    Username = username,

                }).ConfigureAwait(false)).FirstOrDefault();
        }
    }
}
