using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.Repository.Tests.AppModules;
using Reface.AppStarter.UnitTests;
using System.Linq;

namespace Reface.AppStarter.Repository.Tests
{
    [TestClass]
    public class JustEntityScanTests : TestClassBase<JustEntityScanAppModule>
    {
        public ITransactionCounter Counter { get; set; }
        [TestMethod]
        public void ComponentIsRepositoryIsNull()
        {
            Assert.IsNull(Counter);
        }

        [TestMethod]
        public void CanGetEntityFromApp()
        {
            var entityTypes = this.App.GetEntityTypes();
            Assert.AreEqual(1, entityTypes.Count());
        }
    }
}
