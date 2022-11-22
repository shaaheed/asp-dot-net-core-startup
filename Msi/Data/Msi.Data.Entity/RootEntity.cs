using System;

namespace Msi.Data.Entity
{
    [IgnoredEntity]
    public abstract class RootEntity : RootEntity<Guid>, IGuidEntity
    {
    }
}
