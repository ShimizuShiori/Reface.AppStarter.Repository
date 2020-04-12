using Reface.AppStarter.Events;
using Reface.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reface.AppStarter.AppContainers
{
    public class EntityAppContainer : IAppContainer
    {
        public IEnumerable<Type> EntityTypes { get; private set; }

        public EntityAppContainer(IEnumerable<Type> entityTypes)
        {
            EntityTypes = entityTypes;
        }

        public void Dispose()
        {
        }

        public void OnAppPrepair(App app)
        {
        }

        public void OnAppStarted(App app)
        {
            IComponentContainer componentContainer = app.GetAppContainer<IComponentContainer>();
            using (var scope = componentContainer.BeginScope("EntitiesFound"))
            {
                IEventBus eventBus = scope.CreateComponent<IEventBus>();
                eventBus.Publish(new EntitiesFoundEvent(this, this.EntityTypes));
            }
        }
    }
}
