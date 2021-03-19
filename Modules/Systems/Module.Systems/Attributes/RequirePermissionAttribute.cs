using System;

namespace Module.Systems.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class RequirePermissionAttribute : Attribute
    {

        public long[] _permissions;

        public RequirePermissionAttribute(params long[] permissions)
        {
            _permissions = permissions;
        }

    }
}
