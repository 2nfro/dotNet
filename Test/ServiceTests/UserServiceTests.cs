using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Nfro.Services.Core;
using Nfro.Core.Objects.Business;
using Nfro.Core.Objects.Results;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace Test.ServiceTests {

    [TestFixture]
    public class UserServiceTests {

        UserInfo userInfo = new UserInfo() { Email = "test@test.com", Name = "test" };

        //TODO: Make general test that inherits from DatabaseTests
        [Test]
        public void ShouldCreateNewUser() {
            UserService service = new UserService();
            Result result = service.CreateNewUser(userInfo, "testtest");
            Assert.True(result.Success, String.Concat(result.Errors));
        }

        //TODO: Make general test that inherits from DatabaseTests
        [Test]
        public void ShouldActivateUser() {
            UserService service = new UserService();
            service.ActivateUser(2, "SMBU7DUY7");
        }

        //TODO: Make general test that inherits from DatabaseTests
        [Test]
        public void ShouldAuhtenticateUser() {
            UserService service = new UserService();
            TokenValueResult result = service.AuthenticateUser(userInfo, "testtest", Nfro.Core.Objects.Device.None);
            Assert.True(result.Success, String.Concat(result.Errors));
            Assert.NotNull(result.Token);
            Console.Out.WriteLine("Token is {0}.", result.Token.TokenString);
            service.LogOut(2, Nfro.Core.Objects.Device.None);
        }
    }
}
