using Entities.Dtos.UserDtos;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IUserSerive
    {
        Task<IEnumerable<UserDetailDto>> GetListAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> AddAsync(UserAddDto UserAddDto);
        Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto);
        Task<bool> DeleteAsync(int id);
    }
}

