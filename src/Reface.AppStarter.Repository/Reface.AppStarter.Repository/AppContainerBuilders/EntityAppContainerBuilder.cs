using Reface.AppStarter.AppContainers;
using System;
using System.Collections.Generic;

namespace Reface.AppStarter.AppContainerBuilders
{
    public class EntityAppContainerBuilder : BaseAppContainerBuilder
    {
        private readonly List<Type> entityTypes = new List<Type>();

        public void RegisterEntityType(Type type)
        {
            this.entityTypes.Add(type);
        }

        public override IAppContainer Build(AppSetup setup)
        {
            return new EntityAppContainer(this.entityTypes);
        }
    }
}
