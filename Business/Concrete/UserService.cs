using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.User;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly AppSettings _appSettings;
        IMapper _mapper;

        public UserService(IUserDal userDal, AppSettings appSettings)
        {
            _userDal = userDal;
            _appSettings = appSettings;
        }
        public async Task<ApiDataResponse<IEnumerable<UserDetailDto>>> GetListAsync(Expression<Func<User, bool>> filter = null)
        {
            if(filter==null)
            {
                var response = await _userDal.GetListAsync();
                var userDetailDtos = _mapper.Map<IEnumerable<UserDetailDto>>(response);
                return new SuccessApiDataResponse<IEnumerable<UserDetailDto>>(userDetailDtos, Messages.Listed);
            }
            else
            {
                var response = await _userDal.GetListAsync(filter);
                var userDetailDtos = _mapper.Map<IEnumerable<UserDetailDto>>(response);
                return new SuccessApiDataResponse<IEnumerable<UserDetailDto>>(userDetailDtos, Messages.Listed);
            }
        }
        public async Task<ApiDataResponse<UserDto>> GetAsync(Expression<Func<User, bool>> filter = null)
        {
            var user= await _userDal.GetAsync(filter);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return new SuccessApiDataResponse<UserDto>(userDto, Messages.Listed);
            }
            return new ErrorApiDataResponse<UserDto>(null, Messages.NotListed);
        }


        public async Task<ApiDataResponse<UserDto>> AddAsync(UserAddDto userAddDto)
        {
            var user= _mapper.Map<User>(userAddDto);
            //Todo:CreatedDate ve CreatedUserId düzenlenecek
            user.CreatedDate = DateTime.Now;
            user.CreatedUserId = 1; 
            var userAdd = await _userDal.AddAsync(user);
            var userDto = _mapper.Map<UserDto>(userAdd);
           
            return new SuccessApiDataResponse<UserDto>(userDto, Messages.Added); 
        }

        public async Task<ApiDataResponse<UserDto>> GetByIdAsync(int id)
        {
            var user = await _userDal.GetAsync(x => x.Id == id);
            if (user != null)
            {
                var userDto= _mapper.Map<UserDto>(user);
                return new SuccessApiDataResponse<UserDto>(userDto, Messages.Listed);
            }
            return new ErrorApiDataResponse<UserDto>(null,Messages.NotListed);
        }


        public async Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var getUser = await _userDal.GetAsync(x => x.Id == userUpdateDto.Id);
            var user = _mapper.Map<User>(userUpdateDto);
            user.CreatedDate=getUser.CreatedDate;
            user.CreatedUserId = userUpdateDto.Id;
            user.UpdatedDate = DateTime.Now;
            user.UpdatedUserId = 1;
            user.Token=userUpdateDto.Token;
            user.TokenExpireDate=userUpdateDto.TokenExpireDate;
            var resultUpdate = await _userDal.UpdateAsync(user);
            var userUpdateMap = _mapper.Map<UserUpdateDto>(resultUpdate);

            return new SuccessApiDataResponse<UserUpdateDto>(userUpdateMap, Messages.Updated); 
        }

        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return new SuccessApiDataResponse<bool>(await _userDal.DeleteAsync(id));
        }

        //public async Task<ApiDataResponse<AccessToken>> Authenticate(UserForLoginDto userForLoginDto)
        //{
        //    var user = await _userDal.GetAsync(x => x.UserName == userForLoginDto.UserName && x.Password == userForLoginDto.Password);
        //    if (user == null)
        //        return null;
        //    var tokenhandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);
        //    var tokenDescription = new SecurityTokenDescriptor()
        //    {
        //        Subject = new System.Security.Claims.ClaimsIdentity(new[]
        //        {
        //            new Claim(ClaimTypes.Name,user.Id.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenhandler.CreateToken(tokenDescription);
        //    AccessToken accessToken = new AccessToken()
        //    {
        //        Token = tokenhandler.WriteToken(token),
        //        UserName = user.UserName,
        //        Expression = (DateTime)tokenDescription.Expires,
        //        UserID = (int)user.Id
        //    };

        //}
    }
}
