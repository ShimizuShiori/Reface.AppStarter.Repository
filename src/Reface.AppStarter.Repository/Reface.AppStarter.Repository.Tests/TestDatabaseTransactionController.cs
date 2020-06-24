using Reface.AppStarter.Attributes;
using System.Diagnostics;

namespace Reface.AppStarter.Repository.Tests
{
    [Component]
    public class TestDatabaseTransactionController : IDatabaseTransactionController
    {
        private readonly App app;

        public TestDatabaseTransactionController(App app)
        {
            this.app = app;
        }

        public TestDatabaseTransactionController()
        {
            Debug.WriteLine("TestTransactionManager.Ctor");
        }
        public void Begin()
        {
            app.GetTrack().Add("Begin");
        }

        public void Commit()
        {
            app.GetTrack().Add("Commit");
        }

        public void Rollback()
        {
            app.GetTrack().Add("Rollback");
        }
    }
}
