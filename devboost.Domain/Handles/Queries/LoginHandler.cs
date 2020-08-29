using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Queries.Filters;
using devboost.Domain.Queries.Result;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Queries
{
    public class LoginHandler : ILoginHandler
    {

        readonly IUserHandler _userService;
        readonly ITokenHandler _tokenService;

        public LoginHandler(IUserHandler userService, ITokenHandler tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<QueryLoginResult> LoginUser(QueryUserFilter queryUserFilter)
        {
            var user = await _userService.GetUser(queryUserFilter);
            if (user == null || !user.SenhaEValida(queryUserFilter.Password))
                return new QueryLoginResult
                {
                    Token = string.Empty,
                    Message = "Usuário não encontrado ou senha inválida",
                    Valid = false
                };
            var token = await _tokenService.GenerateToken(user);
            return new QueryLoginResult
            {
                Token = token,
                Message = "Token gerado com sucessso",
                Valid = true
            };
        }
    }
}
