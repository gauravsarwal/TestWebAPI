using TestWebAPI.Model;

namespace TestWebAPI.Services
{
    public interface IUserService
    {
        void SaveUserToFile(UserModel model);

    }
}
