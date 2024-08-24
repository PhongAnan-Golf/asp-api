using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;

namespace api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(IHttpContextAccessor httpContextAccessor )
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<string> GetEnvironmentUsernameAsync()
        {
            var nidUser = Environment.UserName;
            return Task.FromResult(nidUser);
        }

        public Task<string> GetLoginUsernameAsync()
        {
            var loginUserName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var username = loginUserName.Contains("\\") ? loginUserName.Split('\\')[1] : loginUserName;
            return Task.FromResult(username);
        }
    }
}