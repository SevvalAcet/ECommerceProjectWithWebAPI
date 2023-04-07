using Core.Utilities.Responses;
using Entities.Dtos.Auth;
using Entities.Dtos.User;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto);
    }
}
