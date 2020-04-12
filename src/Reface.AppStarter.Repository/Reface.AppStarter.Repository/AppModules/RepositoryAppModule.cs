using Reface.AppStarter.AppContainerBuilders;
using Reface.AppStarter.Attributes;
using System.Linq;

namespace Reface.AppStarter.AppModules
{
    public class RepositoryAppModule : AppModule
    {
        private readonly IAppModule entityModule;

        public RepositoryAppModule(IAppModule entityModule)
        {
            this.entityModule = entityModule;
        }

        public RepositoryAppModule() : this(null)
        {

        }

        public override void OnUsing(AppSetup setup, IAppModule targetModule)
        {
            IAppModule entityModule = this.entityModule;
            if (entityModule == null)
                entityModule = targetModule;

            var builder = setup.GetAppContainerBuilder<EntityAppContainerBuilder>();

            var infos = setup.GetScanResult(entityModule);
            infos.ScannableAttributeAndTypeInfos
                .Where(x => x.Attribute is EntityAttribute)
                .ForEach(info => builder.RegisterEntityType(info.Type));
        }
    }
}
