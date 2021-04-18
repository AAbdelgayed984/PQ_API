using System.Collections.Generic;
using PQ_API.Classes;

namespace PQ_API.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(string userId);
    }
}