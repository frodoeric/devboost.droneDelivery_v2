using devboost.Domain.Model;
using System.Threading.Tasks;

namespace devboost.Domain.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUser(string userName);
        Task<User> Create(User user);
    }
}
