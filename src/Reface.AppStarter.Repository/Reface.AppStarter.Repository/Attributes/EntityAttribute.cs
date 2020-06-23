using System;

namespace Reface.AppStarter.Attributes
{
    /// <summary>
    /// 标识一个实体类型
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class EntityAttribute : ScannableAttribute
    {
    }
}
