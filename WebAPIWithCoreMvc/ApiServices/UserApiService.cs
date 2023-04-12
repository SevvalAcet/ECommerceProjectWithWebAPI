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

        public async Task<List<UserDetailDto>> GetListAsync()
        {
            var response = await _httpClient.GetAsync("Users/GetList");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseSuccess = await response.Content.ReadFromJsonAsync<ApiDataResponse<IEnumerable<UserDetailDto>>>();
            return responseSuccess.Data.ToList();
        }

        public Task<ApiDataResponse<List<UserDto>>> GetListDetailAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto appUserUpdateDto)
        {
            throw new NotImplementedException();
        }

        Task<ApiDataResponse<List<UserDto>>> IUserApiService.GetListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
