using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.Repository.Tests.AppModules;
using Reface.AppStarter.UnitTests;

namespace Reface.AppStarter.Repository.Tests
{
    [TestClass]
    public class JustRepositoryTests:TestClassBase<JustRepositoryAppModule>
    {
        [TestMethod]
        public void NoEntityTypesOnApp()
        {
            Assert.IsFalse(this.App.Context.ContainsKey("EntityTypes"));
        }

        public ITransactionCounter Counter { get; set; }

        [TestMethod]
        public void CounterIsNotNull()
        {
            Assert.IsNotNull(Counter);
        }
    }
}
