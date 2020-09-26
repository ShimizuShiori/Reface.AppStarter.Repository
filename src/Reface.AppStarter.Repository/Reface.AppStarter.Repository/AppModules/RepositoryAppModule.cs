namespace Reface.AppStarter.AppModules
{
    /// <summary>
    /// 数据仓库模块
    /// </summary>
    [ComponentScanAppModule
        (
            ExcludeNamespaces = new string[] 
            {
                "Reface.AppStarter.Repository.Listeners"
            }
        )]
    [ProxyAppModule]
    public class RepositoryAppModule : AppModule
    {
    }
}
