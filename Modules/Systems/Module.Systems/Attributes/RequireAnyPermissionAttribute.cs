using System;

namespace Module.Systems.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class RequireAnyPermissionAttribute : Attribute
    {

        public string[] _permissions;

        public RequireAnyPermissionAttribute(params string[] permissions)
        {
            _permissions = permissions;
        }

    }
}
