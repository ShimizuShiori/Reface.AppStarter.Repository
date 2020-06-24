using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.ComponentLifetimeListeners;
using Reface.AppStarter.Repository.Tests.Sercices;
using Reface.AppStarter.UnitTests;
using System.Collections.Generic;

namespace Reface.AppStarter.Repository.Tests
{
    [TestClass]
    public class TransactionTests : TestClassBase<TestAppModule>, IOnPropertiesInjected
    {
        public IUserService UserService { get; set; }

        public ICurrentTransactionManagerAccessor CurrentTransactionManagerAccessor { get; set; }

        public ITranscationManager TranscationManager { get; set; }

        private ITranscationManager transcationManager;

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

        [TestMethod]
        public void TwoTMAreSame()
        {
            Assert.AreSame(transcationManager, TranscationManager);
        }

        [TestMethod]
        public void TestNestedTran()
        {
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin" });
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin" });
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin" });
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin" });
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin" });

            TranscationManager.Commit();
            App.AssertTrack(new List<string>() { "Begin" });
            TranscationManager.Commit();
            App.AssertTrack(new List<string>() { "Begin" });
            TranscationManager.Commit();
            App.AssertTrack(new List<string>() { "Begin" });
            TranscationManager.Commit();
            App.AssertTrack(new List<string>() { "Begin" });
            TranscationManager.Commit();
            App.AssertTrack(new List<string>() { "Begin", "Commit" });
        }

        [TestMethod]
        public void TestNestedTran2()
        {
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin" });
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin" });
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin" });
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin" });
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin" });

            TranscationManager.Rollback();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
            TranscationManager.Rollback();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
            TranscationManager.Rollback();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
            TranscationManager.Rollback();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
            TranscationManager.Rollback();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });

            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
            TranscationManager.Begin();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });

            TranscationManager.Commit();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
            TranscationManager.Commit();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
            TranscationManager.Commit();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
            TranscationManager.Commit();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
            TranscationManager.Commit();
            App.AssertTrack(new List<string>() { "Begin", "Rollback" });
        }

        public void OnPropertiesInjected()
        {
            this.transcationManager = CurrentTransactionManagerAccessor.Get();
        }
    }
}
