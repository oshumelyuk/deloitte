using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Deloitte.Contracts;
using Deloitte.DAL.Interfaces;
using Deloitte.Entities;
using Microsoft.Practices.TransientFaultHandling;
using Newtonsoft.Json;

namespace Deloitte.DAL
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<AccountValidationResult> ValidateAccountAsync(string login, string password)
        {
            try
            {
                Guard.ArgumentNotNullOrEmptyString(login, nameof(login));
                Guard.ArgumentNotNullOrEmptyString(password, nameof(password));

                var allAccounts = await accountsDb.Value;
                Account account = null;

                if (allAccounts.TryGetValue(login, out account))
                {
                    var isValid = string.Equals(account.Password, password, StringComparison.Ordinal);
                    return new AccountValidationResult
                    {
                        Account = new AccountData(account),
                        IsValid = isValid
                    };
                }
            }
            catch (Exception e)
            {
                await Logger.Instance.LogAsync(e);
            }
            return new AccountValidationResult() {
                Account = null,
                IsValid = false
            };
        }

        public async Task<AccountData> GetAccountAsync(string login)
        {
            Guard.ArgumentNotNullOrEmptyString(login, nameof(login));

            var allAccounts = await accountsDb.Value;
            Account account = null;

            return allAccounts.TryGetValue(login, out account)
                ? new AccountData(account)
                : null;
        }

        #region private

        private static Lazy<Task<IDictionary<string, Account>>> accountsDb = new Lazy<Task<IDictionary<string, Account>>>(() => Task.Run(ReadAccountsFromFile));

        private static async Task<IDictionary<string, Account>> ReadAccountsFromFile()
        {
            try
            {
                var absolutePath = DeloitteHostingEnvironment.Get(accountsFilePath);
                var text = File.ReadAllText(absolutePath);
                var parsed = JsonConvert.DeserializeObject<IEnumerable<Account>>(text);
                return parsed.ToDictionary(x => x.Login, x => x, StringComparer.OrdinalIgnoreCase);
            }
            catch (Exception e)
            {
                await Logger.Instance.LogAsync(e);
            }

            return new Dictionary<string, Account>(0);
        }

        private const string accountsFilePath = "\\data\\accounts.json";

        #endregion
    }
}
