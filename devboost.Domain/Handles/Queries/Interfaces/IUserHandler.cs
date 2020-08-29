using devboost.Domain.Model;
using devboost.Domain.Queries.Filters;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Queries.Interfaces
{
    public interface IUserHandler
    {
        Task<User> GetUser(QueryUserFilter userDTO);
    }
}
