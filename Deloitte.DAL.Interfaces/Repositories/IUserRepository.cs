using System.Collections.Generic;
using System.Threading.Tasks;
using Deloitte.Contracts;
using Deloitte.Entities;

namespace Deloitte.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<IList<UserData>> ListAllAsync();

        Task<User> GetUserAsync(string userid);
    }
}
