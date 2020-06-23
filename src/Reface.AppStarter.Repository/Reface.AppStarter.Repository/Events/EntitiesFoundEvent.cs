using Reface.EventBus;
using System;
using System.Collections.Generic;

namespace Reface.AppStarter.Events
{
    /// <summary>
    /// 所有实体被发现后的事件
    /// </summary>
    public class EntitiesFoundEvent : Event
    {
        /// <summary>
        /// 系统中的所有实体类型集合
        /// </summary>
        public IEnumerable<Type> EntityTypes { get; private set; }
        public EntitiesFoundEvent(object source, IEnumerable<Type> entityTypes) : base(source)
        {
            this.EntityTypes = entityTypes;
        }
    }
}
