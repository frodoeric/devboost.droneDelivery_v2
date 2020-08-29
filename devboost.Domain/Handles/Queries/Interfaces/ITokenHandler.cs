using devboost.Domain.Model;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Queries.Interfaces
{
    public interface ITokenHandler
    {
        Task<string> GenerateToken(User user);
    }
}
