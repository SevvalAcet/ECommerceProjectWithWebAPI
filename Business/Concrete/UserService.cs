using Business.Abstract;
using Core.Utilities.Security.Token;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserDtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly AppSettings _appSettings;

        public UserService(IUserDal userDal, AppSettings appSettings)
        {
            _userDal = userDal;
            _appSettings = appSettings;
        }
        public async Task<IEnumerable<UserDetailDto>> GetListAsync()
        {
            List<UserDetailDto> userDetailDtos = new List<UserDetailDto>();
            var response = await _userDal.GetListAsync();
            foreach (var item in response.ToList())
            {
                userDetailDtos.Add(new UserDetailDto()
                {
                    Id = (int)item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender == true ? "Kadın" : "Erkek",
                    DateOfBirth = (DateTime)item.DateOfBirth,
                    UserName = item.UserName,
                    Address = item.Address,
                    Email = item.Email
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
                Id = (int)userAdd.Id,
                FirstName = userAdd.FirstName,
                LastName = userAdd.LastName,
                DateOfBirth = (DateTime)userAdd.DateOfBirth,
                UserName = userAdd.UserName,
                Address = userAdd.Address,
                Email = userAdd.Email,
                Gender = (bool)userAdd.Gender
            };
            return userDto;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _userDal.GetAsync(x => x.Id == id);
            if (user != null)
            {
                UserDto userDto = new UserDto()
                {
                    Address = user.Address,
                    DateOfBirth = (DateTime)user.DateOfBirth,
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Id = (int)user.Id,
                    LastName = user.LastName,
                    Password = user.Password
                };
                return userDto;
            }
            return null;
        }


        public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var getUser = await _userDal.GetAsync(x => x.Id == userUpdateDto.Id);
            User user = new User()
            {
                Id = userUpdateDto.Id,
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
                UpdatedDate = DateTime.Now,
                UpdatedUserId = 1
            };
            var userUpdate = await _userDal.UpdateAsync(user);
            UserUpdateDto newUserUpdateDto = new UserUpdateDto()
            {
                Id = (int)userUpdate.Id,
                FirstName = userUpdate.FirstName,
                LastName = userUpdate.LastName,
                DateOfBirth = (DateTime)userUpdate.DateOfBirth,
                UserName = userUpdate.UserName,
                Address = userUpdate.Address,
                Email = userUpdate.Email,
                Gender = (bool)userUpdate.Gender,
                Password = userUpdate.Password,
            };
            return newUserUpdateDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userDal.DeleteAsync(id);
        }

        public async Task<AccessToken> Authenticate(UserForLoginDto userForLoginDto)
        {
            var user = await _userDal.GetAsync(x => x.UserName == userForLoginDto.UserName && x.Password == userForLoginDto.Password);
            if (user == null)
                return null;
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokenDescription);
            AccessToken accessToken = new AccessToken()
            {
                Token = tokenhandler.WriteToken(token),
                UserName = user.UserName,
                Expression = (DateTime)tokenDescription.Expires,
                UserID = (int)user.Id
            };
            return await Task.Run(() => accessToken);
        }
    }
}
