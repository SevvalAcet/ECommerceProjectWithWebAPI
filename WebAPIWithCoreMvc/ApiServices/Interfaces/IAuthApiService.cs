using Core.Utilities.Responses;
using Entities.Dtos.Auth;
using Entities.Dtos.User;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto);
    }
}
