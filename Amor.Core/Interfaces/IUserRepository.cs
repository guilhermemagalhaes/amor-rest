using Amor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<int> Add(User user);
        Task<User> SignIn(string email, string password);

        Task<User> GetUser(int id);
    }
}
