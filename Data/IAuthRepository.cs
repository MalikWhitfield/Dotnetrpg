using System.Threading.Tasks;
using Dotnetrpg.Models;

namespace Dotnetrpg.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    }
}