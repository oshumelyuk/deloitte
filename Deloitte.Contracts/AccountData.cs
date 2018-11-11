using Deloitte.Entities;

namespace Deloitte.Contracts
{
    public class AccountData
    {
        public AccountData()
        {

        }
        public AccountData(Account account)
        {
            Login = account.Login;
            Name = account.Name;
        }

        public string Login { get; set; }
        public string Name { get; set; }
    }
}
