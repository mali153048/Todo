using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.DTO;
using ToDo.Domain.Entities;

namespace ToDo.Application.Contracts.Repositories
{
    public interface IAuthRepository
    {
        Task<User> AuthenticateAsync(string username);
        Task<int> RegisterAsync(User viewModel);
    }
}
