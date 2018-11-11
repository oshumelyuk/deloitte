using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Deloitte.Contracts;
using Deloitte.DAL.Interfaces;
using Deloitte.Entities;
using Newtonsoft.Json;

namespace Deloitte.DAL
{
    public class UserRepository : IUserRepository
    {
        public async Task<IList<UserData>> ListAllAsync()
        {
            var allUsers = await usersDb.Value;
            return allUsers.Select(u => new UserData(u)).ToList();
        }

        public async Task<User> GetUserAsync(string userId)
        {
            var allUsers = await usersDb.Value;
            return allUsers.FirstOrDefault(u => string.Equals(u.Id.ToString(), userId, StringComparison.OrdinalIgnoreCase));
        }

        #region private

        private static Lazy<Task<IList<User>>> usersDb = new Lazy<Task<IList<User>>>(() => Task.Run(ReadUsersFromFile));

        private static async Task<IList<User>> ReadUsersFromFile()
        {
            try
            {
                var absolutePath = DeloitteHostingEnvironment.Get(usersFilePath);
                var text = File.ReadAllText(absolutePath);
                var parsed = JsonConvert.DeserializeObject<IEnumerable<User>>(text);
                return parsed.ToList();
            }
            catch (Exception e)
            {
                await Logger.Instance.LogAsync(e);
            }

            return new List<User>(0);
        }

        private const string usersFilePath = "\\data\\data.json";

        #endregion
    }
}
