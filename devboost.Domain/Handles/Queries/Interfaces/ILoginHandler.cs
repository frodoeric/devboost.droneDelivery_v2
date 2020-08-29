using devboost.Domain.Queries.Filters;
using devboost.Domain.Queries.Result;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Queries.Interfaces
{
    public interface ILoginHandler
    {
        Task<QueryLoginResult> LoginUser(QueryUserFilter queryUserFilter);
    }
}
