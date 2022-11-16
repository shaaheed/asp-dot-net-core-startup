// Copyright (c) Sahidul Islam. All Rights Reserved.
// Author: https://github.com/shaaheed

namespace Msi.Data.Entity
{
    [IgnoredEntity]
    public class NameDescriptionEntity : NameEntity
    {
        public string Description { get; set; }

        public NameDescriptionEntity()
        {

        }

        public NameDescriptionEntity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
