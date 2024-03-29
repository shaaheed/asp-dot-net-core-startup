﻿// Copyright (c) Sahidul Islam. All Rights Reserved.
// Author: https://github.com/shaaheed

using System;

namespace Msi.Data.Entity
{
    [IgnoredEntity]
    public class NameEntity : BaseEntity, INameEntity
    {
        public string Name { get; set; }

        public NameEntity()
        {

        }

        public NameEntity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
