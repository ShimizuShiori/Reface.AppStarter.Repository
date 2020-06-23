using Reface.AppStarter.Attributes;
using Reface.AppStarter.Repository.Proxies;
using System;

namespace Reface.AppStarter.Repository.Tests.Sercices
{
    public interface IUserService
    {
        void Create();
    }

    [Component]
    public class UserService : IUserService
    {
        [Transcation]
        public void Create()
        {
        }
    }
}
