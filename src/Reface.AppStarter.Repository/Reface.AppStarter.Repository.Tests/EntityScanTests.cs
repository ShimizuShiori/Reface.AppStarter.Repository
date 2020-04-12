using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.Repository.Tests.Entities;
using Reface.AppStarter.UnitTests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reface.AppStarter.Repository.Tests
{
    [TestClass]
    public class EntityScanTests : TestClassBase<TestAppModule>
    {
        [TestMethod]
        public void GetTypesFromApp()
        {
            IEnumerable<Type> types = this.App.GetEntityTypes();
            Assert.IsTrue(types.Any());
            Assert.AreEqual(1, types.Count());
            Assert.AreEqual(typeof(UserEntity), types.ElementAt(0));
        }
    }
}
