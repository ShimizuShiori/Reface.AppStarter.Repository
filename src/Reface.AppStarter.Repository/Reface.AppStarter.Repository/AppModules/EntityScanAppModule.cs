using Reface.AppStarter.AppContainerBuilders;
using Reface.AppStarter.Attributes;
using Reface.AppStarter.Events;
using System.Linq;

namespace Reface.AppStarter.AppModules
{
    /// <summary>
    /// 实体扫描模块。
    /// 该模块会扫描 Target 模块中所有标记了 <see cref="EntityAttribute"/> 的类型，并登录为实体。
    /// 所有实体扫描完成后，会抛出 <see cref="EntitiesFoundEvent"/> 事件。
    /// 通知外部系统内所有已知的实体类型。
    /// </summary>
    [ComponentScanAppModule
        (
            IncludeNamespaces = new string[] 
            {
                "Reface.AppStarter.Repository.Listeners"
            }
        )]
    public class EntityScanAppModule : AppModule, INamespaceFilter
    {
        public string[] IncludeNamespaces { get; set; }

        public string[] ExcludeNamespaces { get; set; }

        public override void OnUsing(AppModuleUsingArguments arguments)
        {
            var setup = arguments.AppSetup;

            var builder = setup.GetAppContainerBuilder<EntityAppContainerBuilder>();

            arguments.ScannedAttributeAndTypeInfos
                .Where(x => x.Attribute is EntityAttribute)
                .ForEach(info => builder.RegisterEntityType(info.Type));
        }
    }
}
