using Core.Utilities.Responses;
using Entities.Dtos.User;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class UserApiService : IUserApiService
    {
        private HttpClient _httpClient;
        public Task<ApiDataResponse<UserDto>> AddAsync(UserAddDto userAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiDataResponse<UserDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiDataResponse<List<UserDto>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApiDataResponse<List<UserDto>>> GetListDetailAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto appUserUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
