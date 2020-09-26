using Reface.AppStarter.AppContainers;
using Reface.AppStarter.Attributes;
using Reface.AppStarter.Events;
using Reface.EventBus;

namespace Reface.AppStarter.Repository.Listeners
{
    [Listener]
    public class PublishEntitiesFoundEvent : IEventListener<AppStartingEvent>
    {
        private readonly IWork work;

        public PublishEntitiesFoundEvent(IWork work)
        {
            this.work = work;
        }

        public void Handle(AppStartingEvent @event)
        {
            var container = @event.App.GetAppContainer<EntityAppContainer>();
            this.work.PublishEvent(new EntitiesFoundEvent(this, container.EntityTypes));
        }
    }
}
