using System;
using System.Threading.Tasks;
using Deloitte.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Deloitte.Tests
{
    [TestClass]
    public class AccountRepositoryTests
    {
        [TestMethod]
        public async Task ShouldValidateUserCredentials_Valid()
        {
            var login = "acc3";
            var pwd = "Acc3Pwd";
            var accountRepository = new AccountRepository();
            var validationResult = await accountRepository.ValidateAccountAsync(login, pwd);
            Assert.IsTrue(validationResult.IsValid, "Credentials should be valid");
        }

        [TestMethod]
        public async Task ShouldValidateUserCredentials_CheckCaseSensetivity()
        {
            var login = "ACC3";
            var pwd = "Acc3Pwd";
            var accountRepository = new AccountRepository();
            var validationResult = await accountRepository.ValidateAccountAsync(login, pwd);
            Assert.IsTrue(validationResult.IsValid, "Credentials should be valid");
        }

        [TestMethod]
        public async Task ShouldValidateUserCredentials_InvalidPwd()
        {
            var login = "acc3";
            var pwd = "werwe";
            var accountRepository = new AccountRepository();
            var validationResult = await accountRepository.ValidateAccountAsync(login, pwd);
            Assert.IsFalse(validationResult.IsValid, "Credentials should be invalid. Password incorrect");
        }

        [TestMethod]
        public async Task ShouldValidateUserCredentials_InvalidLogin()
        {
            var login = "acc344";
            var pwd = "werwe";
            var accountRepository = new AccountRepository();
            var validationResult = await accountRepository.ValidateAccountAsync(login, pwd);
            Assert.IsFalse(validationResult.IsValid, "Credentials should be invalid. Login incorrect");
        }

        [TestMethod]
        public async Task ShouldReturnUserDataByLoginWithoutPassword()
        {
            var login = "acc3";
            var name = "Account 3";
            var pwd = "Acc3Pwd";
            var accountRepository = new AccountRepository();
            var account = await accountRepository.GetAccountAsync(login);
            Assert.AreEqual(account.Login, login);
            Assert.AreEqual(account.Name, name);
            Assert.IsNotNull(account);
            var serialized = JsonConvert.SerializeObject(account);
            Assert.IsFalse(serialized.Contains($"{pwd}"), "Returned data should not contain plain password");
        }
    }
}
