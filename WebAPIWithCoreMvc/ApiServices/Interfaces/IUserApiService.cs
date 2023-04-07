using Core.Utilities.Responses;
using Entities.Dtos.User;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IUserApiService
    {
        Task<ApiDataResponse<List<UserDto>>> GetListAsync();
        Task<ApiDataResponse<List<UserDto>>> GetListDetailAsync();
        Task<ApiDataResponse<UserDto>> AddAsync(UserAddDto userAddDto);
        Task<ApiDataResponse<UserDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto appUserUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);

    }
}
