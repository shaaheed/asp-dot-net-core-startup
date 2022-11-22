using System;

namespace Comment.Application.Attributes
{
    public class ResourceAttribute : Attribute
    {
        public string Name { get; set; }
        public string Operation { get; set; }

        public ResourceAttribute(string name)
        {
            Name = name;
        }
        
    }
}
