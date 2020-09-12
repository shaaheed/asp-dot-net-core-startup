using Msi.Data.Entity;
using System.Linq;
using System.Reflection;

namespace Msi.Data.Abstractions
{
    public static class EntityExtensions
    {
        public static bool IsEntity(this IEntity entity)
        {
            var type = entity.GetType();
            if (typeof(IEntity).GetTypeInfo().IsAssignableFrom(type))
            {
                if (!type.CustomAttributes.Any(x => x.AttributeType == typeof(IgnoredEntityAttribute)))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
