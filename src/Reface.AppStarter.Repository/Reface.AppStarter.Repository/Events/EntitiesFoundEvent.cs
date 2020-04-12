using Reface.EventBus;
using System;
using System.Collections.Generic;

namespace Reface.AppStarter.Events
{
    public class EntitiesFoundEvent : Event
    {
        public IEnumerable<Type> EntityTypes { get; private set; }
        public EntitiesFoundEvent(object source, IEnumerable<Type> entityTypes) : base(source)
        {
            this.EntityTypes = entityTypes;
        }
    }
}
