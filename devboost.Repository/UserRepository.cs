using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace devboost.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User> GetUser(string userName)
        {
            return await _dataContext.User.FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
