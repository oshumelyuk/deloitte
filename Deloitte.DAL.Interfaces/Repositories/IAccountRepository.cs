using System.Threading.Tasks;
using Deloitte.Contracts;

namespace Deloitte.DAL.Interfaces
{
    public interface IAccountRepository
    {
        Task<AccountValidationResult> ValidateAccountAsync(string login, string password);

        Task<AccountData> GetAccountAsync(string login);
    }
}
