namespace Core.Utilities.Security.Token
{
    public interface ITokenService
    {
        AccessToken CreateToken(int userId, string userName);
    }
}
