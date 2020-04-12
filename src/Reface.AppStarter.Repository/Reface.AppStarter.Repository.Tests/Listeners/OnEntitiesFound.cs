using Reface.AppStarter.Attributes;
using Reface.AppStarter.Events;
using Reface.EventBus;

namespace Reface.AppStarter.Repository.Tests.Listeners
{
    [Listener]
    public class OnEntitiesFound : IEventListener<EntitiesFoundEvent>
    {
        public App App { get; private set; }

        public OnEntitiesFound(App app)
        {
            App = app;
        }

        public void Handle(EntitiesFoundEvent @event)
        {
            this.App.SetEntityTypes(@event.EntityTypes);
        }
    }
}
