using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.Repository.Tests.Sercices;
using Reface.AppStarter.UnitTests;

namespace Reface.AppStarter.Repository.Tests
{
    [TestClass]
    public class TransactionTests : TestClassBase<TestAppModule>
    {
        public IUserService UserService { get; set; }

        [TestMethod]
        public void UserServiceIsNotInstanceOfUserServie()
        {
            Assert.IsNotInstanceOfType(this.UserService, typeof(UserService));
        }

        [TestMethod]
        public void DoMethodInTransaction()
        {
            this.UserService.Create();
        }
    }
}
