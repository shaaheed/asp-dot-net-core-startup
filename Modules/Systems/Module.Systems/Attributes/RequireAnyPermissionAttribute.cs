using System;

namespace Module.Systems.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class RequireAnyPermissionAttribute : Attribute
    {

        public long[] _permissions;

        public RequireAnyPermissionAttribute(params long[] permissions)
        {
            _permissions = permissions;
        }

    }
}
