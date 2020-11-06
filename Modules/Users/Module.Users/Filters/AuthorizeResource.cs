//using Comment.Application.Permissions;
//using Microsoft.AspNetCore.Mvc.Controllers;
//using Microsoft.AspNetCore.Mvc.Filters;
//using System;
//using System.Reflection;
//using System.Threading.Tasks;

//namespace Comment.Application.Attributes
//{
//    public class AuthorizeResourceAttribute : Attribute, IAsyncActionFilter
//    {

//        public string Resource { get; set; }
//        public string Operation { get; set; }

//        public void OnActionExecuting(ActionExecutingContext context)
//        {
            
//        }

//        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//        {
//            var actionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
//            var controllerResource = actionDescriptor.ControllerTypeInfo.GetCustomAttribute<ResourceAttribute>();
//            var actionCheck = actionDescriptor.MethodInfo.GetCustomAttribute<AuthorizeResourceAttribute>();
//            if (actionCheck != null)
//            {
//                var permissionService = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService));
//                if (permissionService != null)
//                {
//                    string resource = actionCheck.Resource;

//                    if (string.IsNullOrEmpty(resource))
//                    {
//                        resource =  controllerResource?.Name;
//                    }

//                    var authorize = permissionService.Authorise(1, resource, actionCheck.Operation);
//                    if (!authorize)
//                    {
//                        context.HttpContext.Response.StatusCode = 403;
//                        return Task.CompletedTask;
//                    }
//                }
//            }
//            return next();
//        }
//    }
//}
