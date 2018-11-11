using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deloitte.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Deloitte.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        [TestMethod]
        public async Task ShouldValidateUserCredentials_Valid()
        {
            var userRepository = new UserRepository();
            var users = await userRepository.ListAllAsync();
            Assert.AreEqual(users.Count, 10);
            //check few random users
            Assert.IsTrue(users.Count(u => u.Name == "John Smith 1") == 1);
            Assert.IsTrue(users.Count(u => u.Name == "Marry Smith 3") == 1);
            Assert.IsTrue(users.Count(u => u.Name == "John Smith 5") == 1);
        }
    }
}
