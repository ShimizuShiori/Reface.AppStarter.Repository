using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Reface.AppStarter.Repository.Tests
{
    public static class Extensions
    {
        public static IEnumerable<Type> GetEntityTypes(this App app)
        {
            return app.Context["EntityTypes"] as IEnumerable<Type>;
        }

        public static void SetEntityTypes(this App app, IEnumerable<Type> types)
        {
            app.Context["EntityTypes"] = types;
        }
        public static IList<string> GetTrack(this App app)
        {
            return app.Context.GetOrCreate("TRACK", key => new List<string>());
        }

        public static void AssertTrack(this App app, List<string> expectedTrack)
        {
            var existsTrack = app.GetTrack();
            Assert.AreEqual(expectedTrack.Count, existsTrack.Count);
            for (int i = 0; i < existsTrack.Count; i++)
                Assert.AreEqual(expectedTrack[i], expectedTrack[i]);
        }
    }
}
