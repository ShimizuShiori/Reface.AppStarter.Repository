using Reface.AppStarter.Attributes;
using System.Diagnostics;

namespace Reface.AppStarter.Repository.Tests
{
    [Component]
    public class TestTransactionManager : ITranscationManager
    {
        public TestTransactionManager()
        {
            Debug.WriteLine("TestTransactionManager.Ctor");
        }
        public void Begin()
        {
            Debug.WriteLine("Begin Tran");
        }

        public void Commit()
        {
            Debug.WriteLine("Commit Tran");
        }

        public void Rollback()
        {
            Debug.WriteLine("Rollback Tran");
        }
    }
}
