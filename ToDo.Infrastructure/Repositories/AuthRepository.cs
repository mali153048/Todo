using Microsoft.Extensions.Options;
using System.Reflection;
using ToDo.Application.Contracts.Repositories;
using ToDo.Application.DTO;
using ToDo.Domain.Entities;
using ToDo.Infrastructure.ConfigurationModels;

namespace ToDo.Infrastructure.Repositories
{
    public class AuthRepository : BaseRepository, IAuthRepository
    {
        public AuthRepository(IOptions<DBSettings> options) : base(options.Value)
        {

        }

        public async Task<User> AuthenticateAsync(string username)
        {
            var sql = GetResourceFile("ToDo.Infrastructure.SQLQueries.User.GetUserByUsername.sql", Assembly.GetExecutingAssembly());

            return (await QueryAsync<User>(sql,
                new
                {
                    Username = username

                }).ConfigureAwait(false)).FirstOrDefault();
        }

        public async Task<int> RegisterAsync(User viewModel)
        {
            var sql = GetResourceFile("ToDo.Infrastructure.SQLQueries.Auth.RegisterUser.sql", Assembly.GetExecutingAssembly());

            return await ExecuteAsync(sql,
                new
                {
                    Username = viewModel.Username,
                    PasswordHash = viewModel.PasswordHash,
                    PasswordSalt = viewModel.PasswordSalt,
                    CreatedAt = viewModel.CreatedAt,
                    ModifiedAt = viewModel.ModifiedAt
                }).ConfigureAwait(false);
        }
    }
}
