using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using devboost.Domain.Queries.Filters;
using devboost.Domain.Repository;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Queries
{
    public class UserHandler : IUserHandler
    {
        readonly IUserRepository _userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUser(QueryUserFilter userDTO)
        {
            return await _userRepository.GetUser(userDTO.UserName);
        }
    }
}
