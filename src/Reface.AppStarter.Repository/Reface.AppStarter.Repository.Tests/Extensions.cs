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
    }
}
