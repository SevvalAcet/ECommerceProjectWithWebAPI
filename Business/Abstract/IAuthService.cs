using Core.Utilities.Responses;
using Entities.Dtos.UserDtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto);
    }
}
