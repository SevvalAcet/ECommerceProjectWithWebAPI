using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserDtos;
using System.Net.Sockets;

namespace Business.Concrete
{
    public class UserService : IUserService
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
       
    
        public async Task<UserDto> AddAsync(UserAddDto userAddDto)
        {
            User user = new User()
            {
                FirstName = userAddDto.FirstName,
                LastName = userAddDto.LastName,
                DateOfBirth = userAddDto.DateOfBirth,
                UserName = userAddDto.UserName,
                Address = userAddDto.Address,
                Email = userAddDto.Email,
                //Todo:CreatedDate ve CreatedUserId düzenlenecek
                CreatedDate = DateTime.Now,
                CreatedUserId = 1,
                Gender = userAddDto.Gender,
                Password = userAddDto.Password
            };
            var userAdd = await _userDal.AddAsync(user);

            UserDto userDto = new UserDto()
            {
                FirstName = userAdd.FirstName,
                LastName = userAdd.LastName,
                DateOfBirth = userAdd.DateOfBirth,
                UserName = userAdd.UserName,
                Address = userAdd.Address,
                Email = userAdd.Email,
                Gender = userAdd.Gender,
                Id=userAdd.Id
            };
            return userDto;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user =await _userDal.GetAsync(x =>x.Id == id);
            UserDto userDto = new UserDto()
            {
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName,
                Email = user.Email,
                FirstName=user.FirstName,
                Id = user.Id,
                LastName = user.LastName
            };
            return userDto;
        }


        public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var getUser=await _userDal.GetAsync(x=>x.Id==userUpdateDto.Id);
            User user = new User()
            {
                Id= userUpdateDto.Id,
                FirstName = userUpdateDto.FirstName,
                LastName = userUpdateDto.LastName,
                DateOfBirth = userUpdateDto.DateOfBirth,
                UserName = userUpdateDto.UserName,
                Address = userUpdateDto.Address,
                Email = userUpdateDto.Email,
                CreatedDate = getUser.CreatedDate,
                CreatedUserId = getUser.CreatedUserId,
                Gender = userUpdateDto.Gender,
                Password = userUpdateDto.Password,
                UpdatedDate=DateTime.Now,
                UpdatedUserId = 1
            };
            var userUpdate = await _userDal.UpdateAsync(user);
            UserUpdateDto newUserUpdateDto = new UserUpdateDto()
            {
                Id = userUpdate.Id,
                FirstName = userUpdate.FirstName,
                LastName = userUpdate.LastName,
                DateOfBirth = userUpdate.DateOfBirth,
                UserName = userUpdate.UserName,
                Address = userUpdate.Address,
                Email = userUpdate.Email,
                Gender = userUpdate.Gender,
                Password = userUpdate.Password,
            };
            return newUserUpdateDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userDal.DeleteAsync(id);
            
        }
    }
}
