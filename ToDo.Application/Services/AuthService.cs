using System.Security.Claims;
using ToDo.Application.Contracts.Repositories;
using ToDo.Application.Contracts.Services;
using ToDo.Application.DTO;
using ToDo.Application.Responses;
using ToDo.Application.Validators;
using ToDo.Common.EncryptDecrypt;
using ToDo.Domain.Entities;

namespace ToDo.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userepository;
        public AuthService(IUserRepository userRepository, IAuthRepository authRepository)
        {
            _userepository = userRepository;
            _authRepository = authRepository;
        }

        public async Task<LoginResponse> AuthenticateAsync(LoginDTO viewModel)
        {
            var response = new LoginResponse();
            try
            {
                var user = await _userepository.GetUserByUsernameAsync(viewModel.Username).ConfigureAwait(false);

                if (user != null)
                {
                    var isPasswaordValid = SecurityHelper.VerifyPassword(viewModel.Password, user.PasswordHash, user.PasswordSalt);
                    if (isPasswaordValid)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                        };

                        response.Claims = claims;
                    }
                    else
                    {
                        response.Success = false;
                    }
                }
                else
                {
                    response.Success = false;
                }

            }
            catch (Exception)
            {
                response.Success = false;
            }

            if (response.Success == false)
            {
                response.ValidationErrors = new List<string> { "Invalid Username or Password" };
            }

            return response;
        }

        public async Task<BaseResponse> RegisterAsync(RegisterDTO viewModel)
        {
            var response = new BaseResponse();

            try
            {
                var validator = new RegisterViewModelValidator(_userepository);
                var validatorResult = await validator.ValidateAsync(viewModel).ConfigureAwait(false);



                if (!validatorResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "failed";
                    response.ValidationErrors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
                }
                else
                {
                    var secure = SecurityHelper.HashPassword(viewModel.Password);

                    var user = new User();
                    user.Username = viewModel.Username;
                    user.PasswordHash = secure.hash;
                    user.PasswordSalt = secure.salt;

                    var result = await _authRepository.RegisterAsync(user).ConfigureAwait(false);
                    if (result <= 0)
                    {
                        response.Success = false;
                    }
                }

            }
            catch (Exception)
            {
                response.Success = false;
            }

            response.Message = response.Success ? "success" : "500: Internal Server Error";

            return response;
        }
    }
}
