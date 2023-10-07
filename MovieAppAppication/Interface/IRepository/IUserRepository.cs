using MovieAppDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppAppication.Interface.IRepository
{
    public interface IUserRepository
    {
        Task<bool> RegisterUserAsync(User user);
        Task<User> LoginUserAsync(User user);
    }
}
