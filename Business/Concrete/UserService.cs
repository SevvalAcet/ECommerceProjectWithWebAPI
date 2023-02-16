using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dtos.UserDtos;
using System.Net.Sockets;

namespace Business.Concrete
{
    public class UserService : IUserSerive
    {
        private readonly IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<IEnumerable<UserDetailDto>> GetListAsync()
        {
            List<UserDetailDto> userDetailDtos = new List<UserDetailDto>();
            var response = await _userDal.GetListAsync();
            foreach (var item in response.ToList())
            {
                   userDetailDtos.Add(new UserDetailDto()
                   {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender == true ? "Erkek" : "Kadın",
                    DateOfBirth = item.DateOfBirth,
                    UserName = item.UserName,
                    Address = item.Address,
                    Email = item.Email,
                    Id = item.Id
                   });
            }
            return userDetailDtos;
        }
       
    
        public async Task<UserDto> AddAsync(UserAddDto UserAddDto)
        {
            var response 
        }

        public async Task<bool> DeleteAsync(int id)
        {
            
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user =await _userDal.GetAsync(x =>x.Id == id);
            UserDto userDto = new UserDto()
            {
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName,

            };
        }


        public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            
        }
    }
}
