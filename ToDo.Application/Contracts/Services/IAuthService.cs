using ToDo.Application.DTO;
using ToDo.Application.Responses;

namespace ToDo.Application.Contracts.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> AuthenticateAsync(LoginDTO viewModel);
        Task<BaseResponse> RegisterAsync(RegisterDTO viewModel);
    }
}
