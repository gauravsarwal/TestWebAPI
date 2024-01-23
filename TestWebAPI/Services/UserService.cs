using TestWebAPI.Model;
using System.Text.Json;
namespace TestWebAPI.Services
{
    public class UserService : IUserService
    {
        private const string FilePath = "UserData.json";

        public void SaveUserToFile(UserModel model)
        {
            string json = JsonSerializer.Serialize(model);
            // StreamWriter to append the new data to the file
            using StreamWriter streamWriter = File.AppendText(FilePath);
            streamWriter.WriteLine(json);
        }
    }
}
